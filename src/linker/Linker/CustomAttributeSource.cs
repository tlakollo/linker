﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System;
using Mono.Cecil;

namespace Mono.Linker
{
	public class CustomAttributeSource
	{
		private Dictionary<ICustomAttributeProvider, IEnumerable<CustomAttribute>> _xmlCustomAttributes;
<<<<<<< HEAD
=======
		private Dictionary<ICustomAttributeProvider, IEnumerable<Attribute>> _internalAttributes;
>>>>>>> upstream/master

		public CustomAttributeSource ()
		{
			_xmlCustomAttributes = new Dictionary<ICustomAttributeProvider, IEnumerable<CustomAttribute>> ();
<<<<<<< HEAD
=======
			_internalAttributes = new Dictionary<ICustomAttributeProvider, IEnumerable<Attribute>> ();
		}

		public void AddCustomAttributes (ICustomAttributeProvider provider, IEnumerable<CustomAttribute> customAttributes)
		{
			if (!_xmlCustomAttributes.ContainsKey (provider))
				_xmlCustomAttributes[provider] = customAttributes;
			else
				_xmlCustomAttributes[provider] = _xmlCustomAttributes[provider].Concat (customAttributes);
>>>>>>> upstream/master
		}

		public void AddCustomAttributes (ICustomAttributeProvider provider, IEnumerable<CustomAttribute> customAttributes)
		{
			_xmlCustomAttributes[provider] = customAttributes;
		} 

		public IEnumerable<CustomAttribute> GetCustomAttributes (ICustomAttributeProvider provider)
		{
			if (provider.HasCustomAttributes) {
				foreach (var customAttribute in provider.CustomAttributes)
					yield return customAttribute;
			}

<<<<<<< HEAD
			if (_xmlCustomAttributes.ContainsKey (provider)) {
				foreach (var customAttribute in _xmlCustomAttributes.TryGetValue (provider, out var ann) ? ann : null)
=======
			if (_xmlCustomAttributes.TryGetValue (provider, out var annotations)) {
				foreach (var customAttribute in annotations)
>>>>>>> upstream/master
					yield return customAttribute;
			}
		}

		public bool HasCustomAttributes (ICustomAttributeProvider provider)
		{
			if (provider.HasCustomAttributes)
				return true;

<<<<<<< HEAD
			if (_xmlCustomAttributes.ContainsKey (provider)) {
				return true;
			}
=======
			if (_xmlCustomAttributes.ContainsKey (provider))
				return true;
>>>>>>> upstream/master

			return false;
		}

		public void AddInternalAttributes (ICustomAttributeProvider provider, IEnumerable<Attribute> attributes)
		{
			if (!_internalAttributes.ContainsKey (provider))
				_internalAttributes[provider] = attributes;
			else
				_internalAttributes[provider] = _internalAttributes[provider].Concat (attributes);
		}

		public IEnumerable<Attribute> GetInternalAttributes (ICustomAttributeProvider provider)
		{
			if (_internalAttributes.TryGetValue (provider, out var annotations)) {
				foreach (var attribute in annotations)
					yield return attribute;
			}
		}

		public bool HasInternalAttributes (ICustomAttributeProvider provider)
		{
			return _internalAttributes.ContainsKey (provider) ? true : false;
		}

		public bool HasAttributes (ICustomAttributeProvider provider) =>
			HasCustomAttributes (provider) || HasInternalAttributes (provider);
	}
}