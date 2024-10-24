using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrmtoolbox_SetDefaultView.Helpers
{
    public class GetSystemUsers
    {
        public List<Entity> RetrieveUsers(IOrganizationService service, string entityLogicalName, BackgroundWorker worker = null)
        {
            var users = new List<Entity>();

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Retrieve systemusers " + entityLogicalName);
            }

            var usersList = service.RetrieveMultiple(new QueryExpression("systemuser")
            {
                ColumnSet = new ColumnSet("systemuserid", "fullname", "internalemailaddress"),
            });

            users.AddRange(usersList.Entities);
            return users;
        }
    }
}
