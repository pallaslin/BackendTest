using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Myoffice_ACPD
    {
        /// <summary>
        /// 使用者主鍵
        /// </summary>
        [Key]
        [Column(TypeName = "char(20)")]
        [Display(Name = "使用者主鍵")]
        public string ACPD_SID { get; set; }

        /// <summary>
        /// 中文名稱
        /// </summary>
        [Display(Name = "中文名稱")]
        [Column(TypeName = "nvarchar(60)")]
        public string ACPD_Cname { get; set; }

        /// <summary>
        /// 英文名稱
        /// </summary>
        [Display(Name = "英文名稱")]
        [Column(TypeName = "nvarchar(40)")]
        public string ACPD_Ename { get; set; }

        /// <summary>
        /// 簡稱
        /// </summary>
        [Display(Name = "簡稱")]
        [Column(TypeName = "nvarchar(40)")]
        public string ACPD_Sname { get; set; }

        /// <summary>
        /// 使用者信箱
        /// </summary>
        [Display(Name = "使用者信箱")]
        [Column(TypeName = "nvarchar(60)")]
        public string ACPD_Email { get; set; }

        /// <summary>
        /// 狀況
        /// </summary>
        [Display(Name = "狀況")]
        [Column(TypeName = "tinyint")]
        public int? ACPD_Status { get; set; }

        /// <summary>
        /// 是否停用/不可登入
        /// </summary>
        [Display(Name = "是否停用/不可登入")]
        [Column(TypeName = "bit")]
        public bool? ACPD_Stop { get; set; }

        /// <summary>
        /// 停用原因
        /// </summary>
        [Display(Name = "停用原因")]
        [Column(TypeName = "nvarchar(60)")]
        public string ACPD_StopMemo { get; set; }

        /// <summary>
        /// 登入帳號
        /// </summary>
        [Display(Name = "登入帳號")]
        [Column(TypeName = "nvarchar(30)")]
        public string ACPD_LoginID { get; set; }

        /// <summary>
        /// 登入密碼
        /// </summary>
        [Display(Name = "登入密碼")]
        [Column(TypeName = "nvarchar(60)")]
        public string ACPD_LoginPWD { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display(Name = "備註")]
        [Column(TypeName = "nvarchar(120)")]
        public string ACPD_Memo { get; set; }

        /// <summary>
        /// 新增日期
        /// </summary>
        [Display(Name = "新增日期")]
        public DateTime? ACPD_NowDateTime { get; set; }

        /// <summary>
        /// 新增人員代碼
        /// </summary>
        [Display(Name = "新增人員代碼")]
        [Column(TypeName = "nvarchar(20)")]
        public string ACPD_NowID { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [Display(Name = "修改日期")]
        public DateTime? ACPD_UPDDateTime { get; set; }

        /// <summary>
        /// 新增人員代碼
        /// </summary>
        [Display(Name = "新增人員代碼")]
        [Column(TypeName = "nvarchar(20)")]
        public string ACPD_UPDID { get; set; }
    }
}
