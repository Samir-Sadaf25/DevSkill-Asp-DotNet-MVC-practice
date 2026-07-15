using Demo.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure.Data.Seeds
{
    public class RoleSeeds
    {
        public static ApplicationRole[] GetRoles()
        {
            return new ApplicationRole[]
            {
                new ApplicationRole
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "6E775D85-34FB-4329-9419-5F1A3BB6F306"
                },
                new ApplicationRole
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Member",
                    NormalizedName = "MEMBER",
                    ConcurrencyStamp = "50776D0D-2460-48BC-93F3-6286E18C49D2"
                },
                new ApplicationRole
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "Marketing",
                    NormalizedName = "MARKETING",
                    ConcurrencyStamp = "4D395E0A-EEC0-4CCF-B747-CAAD75FCC9FE"
                },
                 new ApplicationRole
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000004"),
                    Name = "Accounting",
                    NormalizedName = "ACCOUNTING",
                    ConcurrencyStamp = "F8E38957-32FE-46DC-8D42-9A6B3C576985"
                }
            };
        }
    }
}