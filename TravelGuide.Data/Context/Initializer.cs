using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Security.Hashing;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Data.Context
{
    public class Initializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            User admin = new User()
            {
                Name = "Onur",
                Surname = "Güdül",
                Email = "onurgudul229@gmail.com",
                IsActive = true,
                IsAdmin = true,
                Username = "onur.gudul",
            };
            context.Users.Add(admin);
            context.SaveChanges();
            List<User> userList = context.Users.ToList();
            for (int i = 0; i < 10; i++)
            {
                Category category = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                };
                context.Categories.Add(category);
                for (int k = 0; k < FakeData.NumberData.GetNumber(5,9); k++)
                {
                    User owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 20)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner
                    };
                    category.Notes.Add(note);
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        User comment_owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];

                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = comment_owner,
                            
                        };

                        note.Comments.Add(comment);
                    }

                    // Fake like

                    //for (int m = 0; m < note.LikeCount; m++)
                    //{
                    //    Liked liked = new Liked()
                    //    {
                    //        LikedUser = userList[m]
                    //    };
                    //    note.Likeds.Add(liked);
                    //}
                }
            }

            

        }
    }
}

