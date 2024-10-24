using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace xrmtoolbox_SetDefaultView.Helpers
{
    public class GetSystemViews
    {
        public List<Entity> RetrieveViews(IOrganizationService service, string entityLogicalName, BackgroundWorker worker = null)
        {
            var items = new List<Entity>();

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Retrieve system views for entity " + entityLogicalName);
            }

            var views = service.RetrieveMultiple(new QueryExpression("savedquery")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                        {
                            new ConditionExpression("returnedtypecode", ConditionOperator.Equal, entityLogicalName),
                            new ConditionExpression("statecode", ConditionOperator.Equal, 0),
                            new ConditionExpression("querytype", ConditionOperator.Equal, 0),
                            new ConditionExpression("fetchxml", ConditionOperator.NotNull),
                        }
                }
            });

            items.AddRange(views.Entities);
            return items;
        }
    }
}
