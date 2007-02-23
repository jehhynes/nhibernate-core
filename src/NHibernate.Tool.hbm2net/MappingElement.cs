/*
* Created on 28-09-2003
* 
* To change the template for this generated file go to Window - Preferences -
* Java - Code Generation - Code and Comments
*/
using System;

using MultiMap = System.Collections.Hashtable;
using Element = System.Xml.XmlElement;

namespace NHibernate.Tool.hbm2net
{
	/// <author>  MAX
	/// 
	/// To change the template for this generated type comment go to Window -
	/// Preferences - Java - Code Generation - Code and Comments
	/// </author>
	public class MappingElement
	{
		public virtual MappingElement ParentElement
		{
			get { return parentElement; }
		}

		public virtual Element XMLElement
		{
			get { return element; }
		}

		public virtual Element Element
		{
			set { this.element = value; }
		}

		protected internal virtual MultiMap MetaAttribs
		{
			get { return metaattribs; }

			set { this.metaattribs = value; }
		}

		private Element element;
		private MappingElement parentElement;
		private MultiMap metaattribs;

		public MappingElement(Element element, MappingElement parentElement)
		{
			this.element = element;
			this.parentElement = parentElement; // merge with parent meta map
			/*
			* MultiMap inherited = null; if (parentModel != null) { inherited =
			* parentModel.getMetaMap(); }
			*/
		}

		/// <summary>Returns true if this element has the meta attribute </summary>
		public virtual bool hasMeta(string attribute)
		{
			return metaattribs.ContainsKey(attribute);
		}

		/* Given a key, return the list of metaattribs. Can return null! */

		public virtual SupportClass.ListCollectionSupport getMeta(string attribute)
		{
			return (SupportClass.ListCollectionSupport) metaattribs[attribute];
		}

		/// <summary> Returns all meta items as one large string.
		/// 
		/// </summary>
		/// <returns> String
		/// </returns>
		public virtual string getMetaAsString(string attribute)
		{
			SupportClass.ListCollectionSupport c = getMeta(attribute);

			return MetaAttributeHelper.getMetaAsString(c);
		}

		public virtual string getMetaAsString(string attribute, string seperator)
		{
			return MetaAttributeHelper.getMetaAsString(getMeta(attribute), seperator);
		}

		public virtual bool getMetaAsBool(string attribute)
		{
			return getMetaAsBool(attribute, false);
		}

		public virtual bool getMetaAsBool(string attribute, bool defaultValue)
		{
			SupportClass.ListCollectionSupport c = getMeta(attribute);

			return MetaAttributeHelper.getMetaAsBool(c, defaultValue);
		}
	}
}