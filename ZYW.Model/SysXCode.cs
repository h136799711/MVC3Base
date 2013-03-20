// ***********************************************************************
// Assembly         : ZYW.Model
// Author           : hebidu
// Created          : 03-11-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-12-2013
// ***********************************************************************
// <copyright file="SysXCode.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Model
{
    #region 引用包

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Resources;

    #endregion

    /// <summary>
    /// 系统编码类
    /// </summary>
    public class SysXCode
    {
        #region 属性
        
        /// <summary>
        /// Gets or sets the XID.自增长long类型
        /// </summary>
        /// <value>The XID.</value>
        [Key]
        [Display(Name = "ID", ResourceType = typeof(ModelDisplayName))]   
        [Range(0,long.MaxValue)]
        public long XID { get; set; }

        /// <summary>
        /// Gets or sets the XCode.
        /// 五位一段
        /// </summary>
        /// <value>The Xcode.</value>
        [Display(Name ="XCode",ResourceType=typeof(ModelDisplayName))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ModelErrorMessage), ErrorMessageResourceName = "XCodeRequired")]
        [StringLength(126, ErrorMessageResourceName = "XCodeLength", ErrorMessageResourceType = typeof(Resources.ModelErrorMessage))]
        public string XCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the X.
        /// </summary>
        /// <value>The name of the X.</value>
        [Display(Name = "Name", ResourceType = typeof(ModelDisplayName))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ModelErrorMessage), ErrorMessageResourceName = "XNameRequired")]
        [StringLength(126, ErrorMessageResourceName = "XNameLength", ErrorMessageResourceType = typeof(Resources.ModelErrorMessage))]
        public string XName { get; set; }
        
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>The order number.</value>
        [Display(Name = "XOrderNumber", ResourceType = typeof(ModelDisplayName))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ModelErrorMessage), ErrorMessageResourceName = "XOrderNumberRequired")]
        [Range(0,100,ErrorMessageResourceType = typeof(Resources.ModelErrorMessage), ErrorMessageResourceName = "XOrderNumberRange")]
        public int XOrderNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parent ID.
        /// </summary>
        /// <value>The parent ID.</value>
        [Display(Name = "XParentID", ResourceType = typeof(ModelDisplayName))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ModelErrorMessage), ErrorMessageResourceName = "XParentIDRequired")]
        [Range(0, long.MaxValue)]
        public long XParentID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置节点路径，此为父节点则为0，依次递增，以 ‘，’符号为分割符
        /// </summary>
        /// <value>The depth.</value>
        [Display(Name = "XDepth", ResourceType = typeof(ModelDisplayName))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ModelErrorMessage), ErrorMessageResourceName = "XDepthRequired")]
        [StringLength(1024,ErrorMessageResourceName="XDepthLength",ErrorMessageResourceType=typeof(Resources.ModelErrorMessage))]
        public string XDepth
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the X source.
        /// </summary>
        /// <value>The X source.</value>
        [Display(Name = "XSource", ResourceType = typeof(ModelDisplayName))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ModelErrorMessage), ErrorMessageResourceName = "XSourceRequired")]
        [StringLength(1024,ErrorMessageResourceType=typeof(Resources.ModelErrorMessage),
            ErrorMessageResourceName="XSourceLength")]
        public string XSource
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>The flag.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">赋值只能为0或1</exception>
        [Display(Name = "XFlag", ResourceType = typeof(ModelDisplayName))]
        [Required(AllowEmptyStrings = false)]
        [Range(0, 1,ErrorMessage="必需为{1}或{2}")]
        public short XFlag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the X type.
        /// </summary>
        /// <value>The name of the X type.</value>
        [Display(Name = "Remark", ResourceType = typeof(ModelDisplayName))]
        [StringLength(512, ErrorMessageResourceName = "RemarkLength", ErrorMessageResourceType = typeof(Resources.ModelErrorMessage))]
        public string XRemark { get; set; }
                
        /// <summary>
        /// Gets or sets the Operation information.
        /// </summary>
        /// <value>The Operation information.</value>
        public virtual ICollection<OperationInformation> opInformation { get; set; }

        #endregion
    }
}
