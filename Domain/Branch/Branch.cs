using Domain.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Branch;

public class Branch
{
    public BranchId Id { get; private set; }    

    public ClientId ClientId { get; private set; }

    public int PhoneNumber { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string Status { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

}
