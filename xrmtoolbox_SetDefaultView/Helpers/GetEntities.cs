using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xrmtoolbox_SetDefaultView.Helpers
{
    public class GetEntities
    {
        public static List<EntityMetadata> GetEntityList(IOrganizationService service)
        {
            List<EntityMetadata> entities = new List<EntityMetadata>();

            // Retrieve the list of entities
            RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest()
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };

            RetrieveAllEntitiesResponse metaDataResponse = (RetrieveAllEntitiesResponse) service.Execute(metaDataRequest);

            //foreach (EntityMetadata entity in metaDataResponse.EntityMetadata)
            //{
            //    entities.Add(entity);
            //}
            entities.AddRange(metaDataResponse.EntityMetadata);

            return entities;
        }

    }
}
