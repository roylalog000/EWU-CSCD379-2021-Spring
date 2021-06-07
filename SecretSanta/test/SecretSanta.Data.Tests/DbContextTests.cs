using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecretSanta.Data.Tests
{
    [TestClass]
    public class DbContextTests
    {
        [TestMethod]
        public async Task Add_NewGroup_Success()
        {
            Group @group;
            using DbContext dbContext = new DbContext();
            string titlePrefix = $"{nameof(DbContextTests)}.{nameof(Add_NewGroup_Success)}";
            async Task RemoveExistingTestGroupsAsync()
            {
                IQueryable<Group>? groups = dbContext.Groups.Where(
                    item => item.Name.StartsWith(titlePrefix));
                    dbContext.Groups.RemoveRange(groups);
                    await dbContext.SaveChangesAsync();
            }

            try
            {
                await RemoveExistingTestGroupsAsync();
                int countBefore = dbContext.Groups.Count();

                @group = new Group() {Name = $"{titlePrefix} " + Guid.NewGuid().ToString()};
                int id = @group.Id;
                dbContext.Groups.Add(@group);
                await dbContext.SaveChangesAsync();
                Assert.AreNotEqual<int>(0, @group.Id);
                Assert.AreEqual(countBefore + 1, dbContext.Groups.Count());
            }
            finally
            {
                await RemoveExistingTestGroupsAsync();
            }
        }
    }
}
