//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeWorkFishingElite
{
    using System;
    using System.Collections.Generic;
    
    public partial class fish_status
    {
        public int id { get; set; }
        public int fishing_asset_id { get; set; }
        public string fish_status1 { get; set; }
        public string population_name { get; set; }
    
        public virtual fishing_asset fishing_asset { get; set; }
    }
}
