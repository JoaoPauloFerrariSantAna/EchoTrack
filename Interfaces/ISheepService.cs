using EchoTrackV2.Repositories;

namespace EchoTrackV2.Interfaces;

public interface ISheepService
{
    public List<SheepRepository> GetSheep();
    public SheepRepository GetSheepById(int id);
}
