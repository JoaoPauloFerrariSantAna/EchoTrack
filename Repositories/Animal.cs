using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

// using EchoTrackV2.Interfaces;

namespace EchoTrackV2.Repositories;

[DebuggerDisplay("FirstName={Name}, Type={Type}")]
public class Animal
{
    [Editable(false)]
    public int Id { get; set; }

    [Length(5, 12, ErrorMessage = "name must have 5 or 12 letters")]
    [Editable(true)]
    public string Name { get; set; }

}
