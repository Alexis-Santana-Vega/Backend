namespace CE.Chepeat.Application.Presenters;
public class UserPresenter : IUserPresenter
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public UserPresenter(IUnitRepository unitRepository, IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Consulta un registro de la tabla CE_Users
    /// </summary>
    /// <returns></returns>
    public async Task<UserDto> GetUser()
    {
        return await _unitRepository.userInfraestructure.GetUser();
    }
}