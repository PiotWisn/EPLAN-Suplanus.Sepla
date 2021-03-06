﻿using System;
using System.Linq;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel;

namespace Suplanus.Sepla.Helper
{
   /// <summary>
   /// Helper class for userdefinied properties
   /// </summary>
   public class UserDefiniedPropertyUtility
   {
      #region Project

      /// <summary>
      /// Return the PropertyValue if not empty
      /// </summary>
      /// <param name="project">EPLAN project</param>
      /// <param name="identName">Identifing name</param>
      /// <returns>PropertyValue</returns>
      public static PropertyValue GetProjectPropertyValueAndCheckIfEmpty(Project project, string identName)
      {
         PropertyValue propertyValue = GetProjectPropertyValue(project, identName);
         if (propertyValue.IsEmpty)
         {
            return null;
         }
         return propertyValue;
      }

      /// <summary>
      /// Returns Project property value with the given name
      /// </summary>
      /// <param name="project">EPLAN project</param>
      /// <param name="identName">Identifing name</param>
      /// <returns>PropertyValue</returns>
      public static PropertyValue GetProjectPropertyValue(Project project, string identName)
      {
         UserDefinedPropertyDefinition userDefProp = project.UserDefinedPropertyDefinitions
            .FirstOrDefault(u => u.IdentifyingName.Equals(identName));
         if (userDefProp != null)
         {
            AnyPropertyId anyPropertyId = userDefProp.Id;
            PropertyValue propertyValue = project.Properties[anyPropertyId];
            return propertyValue;
         }
         return null;
      }

      /// <summary>
      /// Sets a project property
      /// </summary>
      /// <param name="project">EPLAN project</param>
      /// <param name="identName">Identifing name</param>
      /// <param name="value">New value</param>
      public static void SetProjectPropertyValue(Project project, string identName, object value)
      {
         PropertyValue propertyValue = GetProjectPropertyValue(project, identName);
         if (propertyValue != null)
         {
            if (value is bool)
            {
               propertyValue.Set((bool)value);
               return;
            }
            if (value is double)
            {
               propertyValue.Set((double)value);
               return;
            }
            if (value is MultiLangString)
            {
               propertyValue.Set((MultiLangString)value);
               return;
            }
            if (value is PointD)
            {
               propertyValue.Set((PointD)value);
               return;
            }
            if (value is int)
            {
               propertyValue.Set((int)value);
               return;
            }
            if (value is string)
            {
               propertyValue.Set((string)value);
               return;
            }
            if (value is DateTime)
            {
               propertyValue.Set((DateTime)value);
               return;
            }

            throw new Exception("Type not supported");
         }
         throw new Exception("Property not found");
      }
      #endregion

      #region Function

      /// <summary>
      /// Returns the PropertyValue if not empty
      /// </summary>
      /// <param name="function">Function</param>
      /// <param name="identName">Identifing name</param>
      /// <returns>PropertyValue</returns>
      public static PropertyValue GetFunctionPropertyValueAndCheckIfEmpty(Function function, string identName)
      {
         PropertyValue propertyValue = GetFunctionPropertyValue(function, identName);
         if (propertyValue.IsEmpty)
         {
            return null;
         }
         return propertyValue;
      }

      /// <summary>
      /// Returns the PropertyValue
      /// </summary>
      /// <param name="function">Function</param>
      /// <param name="identName">Identifing name</param>
      /// <returns>PropertyValue</returns>
      public static PropertyValue GetFunctionPropertyValue(Function function, string identName)
      {
         UserDefinedPropertyDefinition userDefProp = function.Properties.ExistingIds
            .Select(anyPropertyId => anyPropertyId.Definition)
            .OfType<UserDefinedPropertyDefinition>()
            .FirstOrDefault(obj => obj.IdentifyingName.Equals(identName));
         if (userDefProp != null)
         {
            AnyPropertyId anyPropertyId = userDefProp.Id;
            PropertyValue propertyValue = function.Properties[anyPropertyId];
            return propertyValue;
         }
         return null;
      }

      /// <summary>
      /// Sets a value to PropertyValue
      /// </summary>
      /// <param name="function">Function</param>
      /// <param name="identName">Identifing name</param>
      /// <param name="value">New value</param>
      public static void SetFunctionPropertyValue(Function function, string identName, object value)
      {
         PropertyValue propertyValue = GetFunctionPropertyValue(function, identName);
         if (propertyValue != null)
         {
            if (value is bool)
            {
               propertyValue.Set((bool)value);
               return;
            }
            if (value is double)
            {
               propertyValue.Set((double)value);
               return;
            }
            if (value is MultiLangString)
            {
               propertyValue.Set((MultiLangString)value);
               return;
            }
            if (value is PointD)
            {
               propertyValue.Set((PointD)value);
               return;
            }
            if (value is int)
            {
               propertyValue.Set((int)value);
               return;
            }
            if (value is string)
            {
               propertyValue.Set((string)value);
               return;
            }
            if (value is DateTime)
            {
               propertyValue.Set((DateTime)value);
               return;
            }

            throw new Exception("Type not supported");
         }
         throw new Exception("Property not found");
      }
      #endregion
   }
}
