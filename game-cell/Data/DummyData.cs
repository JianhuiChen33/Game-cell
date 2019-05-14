using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using game_cell.Data;
using game_cell.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace game_cell.Data
{
    public class DummyData
    {
        public static Platforms[] Platformss { get; private set; }
        public static GAME[] GAMEs { get; private set; }

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Look for any provices.
                if (context.Platformss.Any()
                    && context.GAMEs.Any())
                {
                    return;   // DB has already been seeded
                }

                var Platformss = DummyData.GetPlatforms().ToArray();
                context.Platformss.AddRange(Platformss);
                context.SaveChanges();

                var GAMEs = DummyData.GetGAMEs(context).ToArray();
                context.GAMEs.AddRange(GAMEs);
                context.SaveChanges();
            }
        }

        public static List<Platforms> GetPlatforms()
        {
            List<Platforms> provinces = new List<Platforms>() {
            new Platforms() {
                Name="PC Platforms",
               //PlatformsId=1,
            },
            new Platforms() {
                Name="Nintendo Switch",
                //PlatformsId=2,
            },
        };

            return provinces;
        }

        public static List<GAME> GetGAMEs(ApplicationDbContext context)
        {
            List<GAME> GAMEs = new List<GAME>() {
            new GAME() {
                GAMEName = "League of Legends",
                PlatformsId = 1,
            },
            new GAME() {
                GAMEName = "Monster hunter world(モンスターハンターワールド)",
                PlatformsId = 1,
            },
            new GAME() {
                GAMEName = "Final fantasy XV(ファイナルファンタジーXV)",
                PlatformsId = 1,
            },
            new GAME() {
                GAMEName = "SEKIRO: Shadows Die Twice(隻狼)",
                PlatformsId = 1,
            },
            new GAME() {
                GAMEName = "Legend of Zelda(ゼルダの伝说)",
                PlatformsId = 2,
            },
            new GAME() {
                GAMEName = "Splatoon 2(スプラトゥーン2)",
                PlatformsId = 2,
            },
            new GAME() {
                GAMEName = "Mario Kart 8(マリオカート8)",
                PlatformsId = 2,
            },
            new GAME() {
                GAMEName = "Hollow Knight",
                PlatformsId = 2,
            },           
        };

            return GAMEs;
        }


    }
}
