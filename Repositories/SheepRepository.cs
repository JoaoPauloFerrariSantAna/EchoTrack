using EchoTrackV2.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EchoTrackV2.Repositories;

public class SheepRepository
{
    [Editable(false)]
    public int Id { get; set; }

    [Length(5, 12, ErrorMessage = "name must have 5 or 12 letters")]
    [Editable(true)]
    public string Name { get; set; }
}