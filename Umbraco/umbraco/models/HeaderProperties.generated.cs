//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v13.6.0-rc+16749a7
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	// Mixin Content Type with alias "headerProperties"
	/// <summary>Header Properties</summary>
	public partial interface IHeaderProperties : IPublishedElement
	{
		/// <summary>Header Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		global::Umbraco.Cms.Core.PropertyEditors.ValueConverters.ImageCropperValue HeaderImage { get; }

		/// <summary>Subtitle</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string Subtitle { get; }

		/// <summary>Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string Title { get; }
	}

	/// <summary>Header Properties</summary>
	[PublishedModel("headerProperties")]
	public partial class HeaderProperties : PublishedElementModel, IHeaderProperties
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		public new const string ModelTypeAlias = "headerProperties";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<HeaderProperties, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public HeaderProperties(IPublishedElement content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Header Image: Choose the image header for this page
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("headerImage")]
		public virtual global::Umbraco.Cms.Core.PropertyEditors.ValueConverters.ImageCropperValue HeaderImage => GetHeaderImage(this, _publishedValueFallback);

		/// <summary>Static getter for Header Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static global::Umbraco.Cms.Core.PropertyEditors.ValueConverters.ImageCropperValue GetHeaderImage(IHeaderProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<global::Umbraco.Cms.Core.PropertyEditors.ValueConverters.ImageCropperValue>(publishedValueFallback, "headerImage");

		///<summary>
		/// Subtitle: Enter The Subtitle for this page
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("subtitle")]
		public virtual string Subtitle => GetSubtitle(this, _publishedValueFallback);

		/// <summary>Static getter for Subtitle</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetSubtitle(IHeaderProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "subtitle");

		///<summary>
		/// Title: Enter a title for this page
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("title")]
		public virtual string Title => GetTitle(this, _publishedValueFallback);

		/// <summary>Static getter for Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.6.0-rc+16749a7")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetTitle(IHeaderProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "title");
	}
}
