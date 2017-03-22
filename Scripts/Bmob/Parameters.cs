using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters
{

    public static string parameters 
    {
        get{return "parameters";}
    }
    public string KCEvent { get; set; }
    public object parame { get; set; }

    public Parameters(KCEvent KCEvent, object parame)
    {
        this.KCEvent = KCEvent.ToString();
        this.parame = parame;
    }

    public static Dictionary<string, object> GetParameteres(KCEvent KCEvent, object parame)
    {
        Dictionary<string, object> ps = new Dictionary<string, object>();
        ps.Add(parameters, new Parameters(KCEvent, parame));
        return ps;
    }
}
