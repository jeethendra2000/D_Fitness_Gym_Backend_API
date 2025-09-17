using D_Fitness_Gym.Data;
using D_Fitness_Gym.Models.Entities;
using D_Fitness_Gym.Repositories;
using D_Fitness_Gym.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace D_Fitness_Gym.Tests.Controllers
{
    public class RolesControllerUnitTests
    {
        private readonly IRoleRepository _repository;
        private readonly ApplicationDbContext _dbContext;

        public RolesControllerUnitTests()
        {
            // Setup In-Memory DB
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _repository = new RoleRepository(_dbContext); // _repository is typed as IRoleRepository
        }

        [Fact]
        public async Task CreateRole_ShouldAddRole()
        {
            // Arrange
            var role = new Role { Name = "TestRole" };

            // Act
            var createdRole = await ((IBaseRepository<Role>)_repository).CreateAsync(role);
            // Cast to IBaseRepository<Role> to access CreateAsync

            // Assert
            Assert.NotNull(createdRole);
            Assert.Equal("TestRole", createdRole.Name);

            // Optionally check if it exists in DbContext
            var dbRole = await _dbContext.Roles.FindAsync(createdRole.Id);
            Assert.NotNull(dbRole);
        }
    }
}
