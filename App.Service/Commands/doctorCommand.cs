using App.Service.Dtos;
using MediatR;

public record DoctorRegisterCommand(
    string Name,
    string Surname,
    string Registration_number,
    string Password
) : IRequest<DoctorOutputDto>;
