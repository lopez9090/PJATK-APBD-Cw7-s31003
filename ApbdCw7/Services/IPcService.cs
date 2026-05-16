using ApbdCw7.DTOs;

namespace ApbdCw7.Services;

public interface IPcService
{
    Task<IEnumerable<PcResponseDto>> GetAllPcsAsync();
    Task<PcWithComponentsResponseDto?> GetPcWithComponentsAsync(int id);
    Task<PcResponseDto> CreatePcAsync(PcRequestDto dto);
    Task<bool> UpdatePcAsync(int id, PcRequestDto dto);
    Task<bool> DeletePcAsync(int id);
}