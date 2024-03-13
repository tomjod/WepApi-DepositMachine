using Domain.Entities.Branches;
using Domain.Entities.Clients;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ApiKeys;

public class ApiKey 
{
    public Guid Id { get; private set; }
    public string Key { get; private set; }
    public BranchId BranchId { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime Expires { get; private set; }
    public bool IsActive { get; private set; }

    private ApiKey(
        Guid id, 
        string key, 
        BranchId branchId)
    {
        Id = id;
        Key = key;
        Created = DateTime.UtcNow;
        Expires = Created.AddYears(5);
        BranchId = branchId;
    }
    public static ApiKey Create(string key, BranchId branchId) 
    {
        var apikey = new ApiKey(
            Guid.NewGuid(),
            key, 
            branchId);

        return apikey;
    }

}
