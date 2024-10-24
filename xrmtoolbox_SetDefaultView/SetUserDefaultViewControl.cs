using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using xrmtoolbox_SetDefaultView.Helpers;
using System.Runtime.Remoting.Contexts;
using Microsoft.Crm.Sdk.Messages;

namespace xrmtoolbox_SetDefaultView
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings SetUserDefaultViewSetting;
        private ListViewItem[] listViewItems;
        private ListViewItem[] listViewUsers;
        private Thread searchEntity;
        private Thread searchUser;
        private List<string> checkedView;
        private List<string> checkedUsers;
        private string entitySelected;
        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out SetUserDefaultViewSetting))
            {
                SetUserDefaultViewSetting = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
            ExecuteMethod(GetAllEntities);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbsample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAllEntities);
        }
        private void tsbLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(GetAllEntities);
        }

        private void GetAllEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities...",
                Work = (worker, args) =>
                {
                    var entities = GetEntities.GetEntityList(Service);
                    var users = new GetSystemUsers().RetrieveUsers(Service, "systemuser", worker);
                    var result = new
                    {
                        entities,
                        users
                    };
                    args.Result = result;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        lvSystemView.ItemChecked -= listViewSystemView_ItemChecked;
                        listViewSystemUsers.ItemChecked -= listViewSystemUsers_ItemChecked;
                        var result = (dynamic)args.Result;
                        listViewEntities.Items.Clear();
                        EntityMetadata[] entities = ((List<EntityMetadata>)result.entities).ToArray();
                        Entity[] systemUsers = ((List<Entity>)result.users).ToArray();

                        var listEntities = new List<ListViewItem>();
                        var listUsers = new List<ListViewItem>();
                        foreach (EntityMetadata entity in entities)
                        {
                            var displayName = entity.DisplayName?.UserLocalizedLabel?.Label ?? "No Display Name";
                            var item = new ListViewItem { Text = displayName, Tag = entity.LogicalName };
                            item.SubItems.Add(entity.LogicalName);
                            listEntities.Add(item);
                        }
                        listViewItems = listEntities.ToArray();
                        listViewEntities.Items.AddRange(listViewItems);

                        foreach (Entity user in systemUsers)
                        {
                            var fullname = user.GetAttributeValue<string>("fullname");
                            var email = user.GetAttributeValue<string>("internalemailaddress");
                            var systemUser = new ListViewItem { Text = fullname, Tag = user.Id };
                            systemUser.SubItems.Add(email);
                            listUsers.Add(systemUser);
                        }
                        listViewUsers = listUsers.ToArray();
                        listViewSystemUsers.Items.AddRange(listUsers.ToArray());
                        listViewSystemUsers.ItemChecked += listViewSystemUsers_ItemChecked;
                        lvSystemView.ItemChecked += listViewSystemView_ItemChecked;
                        tsbSetDefaultView.Enabled = false;
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), SetUserDefaultViewSetting);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (SetUserDefaultViewSetting != null && detail != null)
            {
                SetUserDefaultViewSetting.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listViewEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEntities.SelectedItems.Count > 0)
            {

                var entityLogicalName = listViewEntities.SelectedItems[0].Tag.ToString();
                entitySelected = entityLogicalName;
                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading views...",
                    Work = (worker, args) =>
                    {
                        args.Result = new GetSystemViews().RetrieveViews(Service, entityLogicalName, worker);
                    },
                    PostWorkCallBack = (args) =>
                    {
                        if (args.Error != null)
                        {
                            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            lvSystemView.ItemChecked -= listViewSystemView_ItemChecked;
                            lvSystemView.Items.Clear();
                            Entity[] views = ((List<Entity>)args.Result).ToArray();

                            var list = new List<ListViewItem>();
                            foreach (Entity view in views)
                            {
                                var displayName = view.GetAttributeValue<string>("name");
                                var item = new ListViewItem { Text = displayName, Tag = view.Id };
                                item.SubItems.Add(view.Id.ToString());
                                list.Add(item);
                            }
                            lvSystemView.Items.AddRange(list.ToArray());
                            lvSystemView.ItemChecked += listViewSystemView_ItemChecked;
                        }
                    }
                });

            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            searchEntity?.Abort();
            searchEntity = new Thread(Search);
            searchEntity.Start(tbSearch.Text);
        }

        public void Search(object term)
        {
            var searchItems = listViewItems.Where(i => string.IsNullOrEmpty(term.ToString()) || i.Text.ToLower().IndexOf(term.ToString().ToLower()) >= 0
            || i.SubItems.Cast<ListViewItem.ListViewSubItem>().Any(s => s.Text.ToLower().IndexOf(term.ToString().ToLower()) >= 0));

            Invoke(new Action(() =>
            {
                listViewEntities.Items.Clear();
                listViewEntities.Items.AddRange(searchItems.ToArray());
            }));
        }

        private void txtFilterUser_TextChanged(object sender, EventArgs e)
        {
            searchUser?.Abort();
            searchUser = new Thread(SearchUser);
            searchUser.Start(tbSearchUser.Text);
        }

        public void SearchUser(object userString)
        {
            var searchUser = listViewUsers.Where(i => string.IsNullOrEmpty(userString.ToString()) || i.Text.ToLower().IndexOf(userString.ToString().ToLower()) >= 0
            || i.SubItems.Cast<ListViewItem.ListViewSubItem>().Any(s => s.Text.ToLower().IndexOf(userString.ToString().ToLower()) >= 0));

            Invoke(new Action(() =>
            {
                listViewSystemUsers.Items.Clear();
                listViewSystemUsers.Items.AddRange(searchUser.ToArray());
            }));
        }

        private void listViewSystemView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            lvSystemView.ItemChecked -= listViewSystemView_ItemChecked;

            foreach (ListViewItem item in lvSystemView.Items)
            {
                if (item != e.Item)
                {
                    item.Checked = false;
                }
            }

            lvSystemView.ItemChecked += listViewSystemView_ItemChecked;
            ListViewItem viewItem = e.Item;
            checkedView = new List<string>();
            if (viewItem.Checked)
            {
                checkedView.Add(viewItem.Tag.ToString());
                tsbSetDefaultView.Enabled = true;
            }
            else
            {
                checkedView.Remove(viewItem.Tag.ToString());
                tsbSetDefaultView.Enabled = false;
            }

        }

        private void listViewSystemUsers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListViewItem userItem = e.Item;
            checkedUsers = new List<string>();
            if (userItem.Checked)
            {
                checkedUsers.Add(userItem.Tag.ToString());
            }
            else
            {
                checkedUsers.Remove(userItem.Tag.ToString());
            }
        }

        private void tsb_SetDefaultView_Click(object sender, EventArgs e)
        {

            string viewId = checkedView.FirstOrDefault();
            RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Entity,
                LogicalName = entitySelected
            };

            RetrieveEntityResponse retrieveEntityResponse = (RetrieveEntityResponse)Service.Execute(retrieveEntityRequest);
            EntityMetadata entityMetadata = retrieveEntityResponse.EntityMetadata;

            int entityTypeCode = entityMetadata.ObjectTypeCode.HasValue ? entityMetadata.ObjectTypeCode.Value : -1;

            if (viewId != string.Empty && entityTypeCode > 0)
            {
                string personalizationSettings = $"<DefaultGridViews><DefaultGridView><EntityTypeCode>{entityTypeCode}</EntityTypeCode><ChildEntityName></ChildEntityName><QueueId></QueueId><ViewId>{{{viewId}}}</ViewId><ViewType>1039</ViewType></DefaultGridView></DefaultGridViews>";
                string[] usersToSet = null;
                if (checkedUsers !=null)
                {
                    usersToSet = checkedUsers.ToArray();
                }
                else
                {
                    MessageBox.Show("Please select a user to set the default view");
                    return;
                }
                Entity userSetting = new Entity("usersettings");
                userSetting["personalizationsettings"] = personalizationSettings;

                foreach (string i in usersToSet)
                {

                    var query = new QueryExpression("usersettings");
                    query.ColumnSet.AddColumns("personalizationsettings", "systemuserid");

                    query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, i);

                    try
                    {
                        userSetting = Service.RetrieveMultiple(query).Entities.FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (userSetting != null)
                    {
                        userSetting["personalizationsettings"] = personalizationSettings;
                        Service.Update(userSetting);

                    }
                }
                MessageBox.Show("Default view set successfully");
            }
            else
            {
                MessageBox.Show("Invalid ViewId");
            }
            
        }

        private void tsbSyncUser_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            string entraID = string.Empty;
            if (form.ShowDialog() == DialogResult.OK)
            {
                entraID = form.EntraID;
                ExecuteForceSync(entraID);
            }
        }

        private void ExecuteForceSync(string entraID)
        {
            var callerObject = ((CrmServiceClient)Service).CallerAADObjectId;
            ((CrmServiceClient)Service).CallerAADObjectId = new Guid(entraID);
            WhoAmIRequest request = new WhoAmIRequest();
            Service.Execute(request);
            ((CrmServiceClient)Service).CallerAADObjectId = callerObject;
            ExecuteMethod(GetAllEntities);
        }

    }
}