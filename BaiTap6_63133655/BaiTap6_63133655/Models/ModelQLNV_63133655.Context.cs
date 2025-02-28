﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiTap6_63133655.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLNV_63133655Entities : DbContext
    {
        public QLNV_63133655Entities()
            : base("name=QLNV_63133655Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<QuanTri> QuanTris { get; set; }
    
        public virtual int NhanVien_TimKiem(string maNV, string hoTen, string gioiTinh, string luongMin, string luongMax, string diaChi, string maPB)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoTenParameter = hoTen != null ?
                new ObjectParameter("HoTen", hoTen) :
                new ObjectParameter("HoTen", typeof(string));
    
            var gioiTinhParameter = gioiTinh != null ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(string));
    
            var luongMinParameter = luongMin != null ?
                new ObjectParameter("LuongMin", luongMin) :
                new ObjectParameter("LuongMin", typeof(string));
    
            var luongMaxParameter = luongMax != null ?
                new ObjectParameter("LuongMax", luongMax) :
                new ObjectParameter("LuongMax", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var maPBParameter = maPB != null ?
                new ObjectParameter("MaPB", maPB) :
                new ObjectParameter("MaPB", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NhanVien_TimKiem", maNVParameter, hoTenParameter, gioiTinhParameter, luongMinParameter, luongMaxParameter, diaChiParameter, maPBParameter);
        }
    }
}
