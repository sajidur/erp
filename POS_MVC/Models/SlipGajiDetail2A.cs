//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RexERP_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SlipGajiDetail2A
    {
        public int Id { get; set; }
        public int SlipGajiDetailId { get; set; }
        public string month { get; set; }
        public string employee_code { get; set; }
        public decimal salary_basic { get; set; }
        public decimal rate_hour { get; set; }
        public decimal allowance_rate { get; set; }
        public decimal uang_makan { get; set; }
        public decimal jml_jam_lembur { get; set; }
        public decimal jml_lembur { get; set; }
        public decimal jml_hari_absen { get; set; }
        public decimal tunj_lap { get; set; }
        public decimal insentive_hadir { get; set; }
        public decimal other_allow { get; set; }
        public decimal krg_bln_lalu { get; set; }
        public decimal thr { get; set; }
        public decimal pot_absensi { get; set; }
        public decimal pot_others { get; set; }
        public decimal gaji_kotor { get; set; }
        public decimal pot_pinjaman { get; set; }
        public decimal pot_jamsostek { get; set; }
        public decimal pjk_jkk_jkm_204 { get; set; }
        public decimal tot_dpt_kotor { get; set; }
        public decimal pjk_tunj_jabatan { get; set; }
        public decimal pjk_ptkp { get; set; }
        public decimal tot_pengurang_pajak { get; set; }
        public decimal tot_dpt_kena_pajak { get; set; }
        public decimal tot_dpt_kena_pajak_tahun { get; set; }
        public decimal pph_5_persen { get; set; }
        public decimal pph_15_persen { get; set; }
        public decimal pph_25_persen { get; set; }
        public decimal pph_30_persen { get; set; }
        public decimal pph21 { get; set; }
        public decimal round { get; set; }
        public decimal gaji_bersih { get; set; }
        public Nullable<int> SlipGajiDetail_Id { get; set; }
    
        public virtual SlipGajiDetail SlipGajiDetail { get; set; }
        public virtual SlipGajiDetail SlipGajiDetail1 { get; set; }
    }
}
