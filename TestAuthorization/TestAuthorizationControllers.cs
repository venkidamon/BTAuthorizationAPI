using Authorization.Controllers;
using Authorization.Data;
using Authorization.Interfaces;
using Authorization.Repository;
using AutoMapper;

namespace TestAuthorization
{
    public class TestAuthorizationControllers
    {

        private readonly UsersController _controller;
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public TestAuthorizationControllers()
        {
            _userRepository = new UserRepository(_context);
            _controller = new UsersController(_userRepository);

        }
        [Fact]
        public void Test1()
        {
            
            var result = _controller.GetUsers();
            Assert.NotNull(result);
        }

        [Fact]
        public void Test2()
        {
            var result = _controller.GetUserByUsername("111111111111");
            Assert.NotNull(result);
        }
    }
}