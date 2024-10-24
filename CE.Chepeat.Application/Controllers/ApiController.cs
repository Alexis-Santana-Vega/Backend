
using CE.Chepeat.Application.Presenters;
using CE.Chepeat.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Application.Controllers
{
    public class ApiController: IApiController
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;


        public ApiController(IUnitRepository unitRepository, IMapper mapper, IConfiguration configuration, IJwtService jwtService, IEmailService emailService)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _configuration = configuration;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        public IUserPresenter UserPresenter => new UserPresenter(_unitRepository, _mapper);    //
        public IAuthPresenter AuthPresenter => new AuthPresenter(_unitRepository, _mapper, _jwtService);
        public ISellerPresenter SellerPresenter => new SellerPresenter(_unitRepository);
        public IProductPresenter ProductPresenter => new ProductPresenter(_unitRepository);
        public IEmailPresenter EmailPresenter => new EmailPresenter(_emailService, _unitRepository);
    }
}
