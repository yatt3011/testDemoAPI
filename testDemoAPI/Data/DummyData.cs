using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testDemoAPI.Models;

namespace testDemoAPI.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {

        }

        public static List<Platform> GetPlatforms(testDemoContext context)
        {
            List<Platform> platforms = new List<Platform>()
            {
                new Platform
                {
                    uniqueName = "Platform 1",
                    wells = new List<Well>(context.wells.Take(1))
                }
            };
            return platforms;
        }
        public static List<Well> GetWells()
        {
            List<Well> wells = new List<Well>()
            {
                new Well
                {
                    platformId = 1,
                    uniqueName = "Well 11",
                    latitude = 37.062570,
                    longitude = 18.406885
                }
            };
            return wells;
        }
        public static List<Dashboard> GetDashboards(testDemoContext context)
        {
            List<Dashboard> dashboards = new List<Dashboard>()
            {
                new Dashboard
                {
                    success = true,
                    chartDonut = new List<ChartDashboard>(context.chartDashboards.Take(1)),
                    chartBar = new List<ChartDashboard>(context.chartDashboards.Take(1)),
                    tableUsers = new List<TableUser>(context.tableUsers.Take(1))
                }
            };
            return dashboards;
        }
        public static List<ChartDashboard> GetChartDashboards()
        {
            List<ChartDashboard> chartDashboards = new List<ChartDashboard>()
            {
                new ChartDashboard
                {
                    name = "Donut Chart",
                    value = 1.0
                },
                new ChartDashboard
                {
                    name = "Bar Chart",
                    value = 2.0
                }
            };
            return chartDashboards;
        }
        public static List<TableUser> GetTableUsers()
        {
            List<TableUser> tableUsers = new List<TableUser>()
            {
                new TableUser
                {
                    firstName = "user",
                    lastName = "aem enarsol",
                    userName = "user@aemenersol.com"
                }
            };
            return tableUsers;
        }
        public static List<LoginRequest> GetLoginRequests()
        {
            List<LoginRequest> loginRequests = new List<LoginRequest>()
            {
                new LoginRequest
                {
                    userName = "user@aemenersol.com",
                    password = "Test@123"
                }
            };
            return loginRequests;
        }        
    }
}
