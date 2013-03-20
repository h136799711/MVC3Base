// ***********************************************************************
// Assembly         : ZYW.Model
// Author           : hebidu
// Created          : 03-14-2013
//
// Last Modified By : hebidu
// Last Modified On : 03-15-2013
// ***********************************************************************
// <copyright file="Book.cs" company="XXX">
//     Copyright (c) XXX. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace ZYW.Model
{
    #region 引用包 

    using System;

    #endregion

    /// <summary>
    /// Class Book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the book ID.
        /// </summary>
        /// <value>The book ID.</value>
        public long bookID 
        { 
            get;
            set; 
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string Summary
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the press.
        /// </summary>
        /// <value>The press.</value>
        public string Press
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the pubish date.
        /// </summary>
        /// <value>The pubish date.</value>
        public DateTime PubDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the catalogue ID.
        /// </summary>
        /// <value>The catalogue ID.</value>
        public long CatalogueID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type ID.
        /// </summary>
        /// <value>The type ID.</value>
        public long TypeID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string URL
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the thumbnail URL.
        /// </summary>
        /// <value>The thumbnail URL.</value>
        public string ThumbnailURL
        {
            get;
            set;
        }
    }
}
