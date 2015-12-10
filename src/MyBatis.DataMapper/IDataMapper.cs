﻿#region Apache Notice
/*****************************************************************************
 * $Revision: 374175 $
 * $LastChangedDate: 2008-06-28 09:26:16 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
 * 
 * MyBatis.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Data;
using MyBatis.DataMapper.Exceptions;

namespace MyBatis.DataMapper
{
    ///<summary>
    /// Main interface the the dataMapper
    ///</summary>
    public interface IDataMapper
    {

        /// <summary>
        ///  Executes a Sql DELETE statement.
        ///  Delete returns the number of rows effected.
        /// </summary>
        /// <param name="statementName">The name of the statement to execute.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns>The number of rows effected.</returns>
        int Delete(string statementName, object parameterObject);

        /// <summary>
        /// Executes a Sql INSERT statement.
        /// Insert is a bit different from other update methods, as it
        /// provides facilities for returning the primary key of the
        /// newly inserted row (rather than the effected rows).  This
        /// functionality is of course optional.
        /// <p/>
        /// The parameter object is generally used to supply the input
        /// data for the INSERT values.
        /// </summary>
        /// <param name="statementName">The name of the statement to execute.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns> The primary key of the newly inserted row.  
        /// This might be automatically generated by the RDBMS, 
        /// or selected from a sequence table or other source.
        /// </returns>
        object Insert(string statementName, object parameterObject);

        /// <summary>
        /// Alias to QueryForMap, .NET spirit.
        ///  Feature idea by Ted Husted.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <returns>A IDictionary (Hashtable) of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        IDictionary QueryForDictionary(string statementName, object parameterObject, string keyProperty, string valueProperty);

        /// <summary>
        ///  Alias to QueryForMap, .NET spirit.
        ///  Feature idea by Ted Husted.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <returns>A IDictionary (Hashtable) of object containing the rows keyed by keyProperty.</returns>
        IDictionary QueryForDictionary(string statementName, object parameterObject, string keyProperty);

        /// <summary>
        /// Executes a Sql SELECT statement that returns data to populate
        /// a number of result objects.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">An Ilist object used to hold the objects.</param>
        /// <returns>A List of result objects.</returns>
        void QueryForList(string statementName, object parameterObject, IList resultObject);

        /// <summary>
        /// Executes a Sql SELECT statement that returns data to populate
        /// a number of result objects.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>A List of result objects.</returns>
        IList QueryForList(string statementName, object parameterObject);

        /// <summary>
        ///  Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        ///  in the keyProperty parameter.  The value at each key will be the entire result object.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <returns>A IDictionary (Hashtable) of object containing the rows keyed by keyProperty.</returns>
        IDictionary QueryForMap(string statementName, object parameterObject, string keyProperty);

        /// <summary>
        /// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        /// in the keyProperty parameter.  The value at each key will be the value of the property specified
        /// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <returns>A IDictionary (Hashtable) of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        IDictionary QueryForMap(string statementName, object parameterObject, string keyProperty, string valueProperty);

        /// <summary>
        /// Runs a query with a custom object that gets a chance to deal 
        /// with each row as it is processed.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate"></param>
        /// <returns>A IDictionary (Hashtable) of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        IDictionary QueryForMapWithRowDelegate(string statementName, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate rowDelegate);

        /// <summary>
        /// Executes a Sql SELECT statement that returns a single object of the type of the
        /// resultObject parameter.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">An object of the type to be returned.</param>
        /// <returns>The single result object populated with the result set data.</returns>
        object QueryForObject(string statementName, object parameterObject, object resultObject);

        /// <summary>
        /// Executes a Sql SELECT statement that returns that returns data 
        /// to populate a single object instance.
        /// <p/>
        /// The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns> The single result object populated with the result set data.</returns>
        object QueryForObject(string statementName, object parameterObject);

        /// <summary>
        /// Runs a query for list with a custom object that gets a chance to deal 
        /// with each row as it is processed.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="rowDelegate"></param>
        /// <returns>A List of result objects.</returns>
        IList QueryWithRowDelegate(string statementName, object parameterObject, RowDelegate rowDelegate);

        /// <summary>
        /// Executes a Sql UPDATE statement.
        /// Update can also be used for any other update statement type,
        /// such as inserts and deletes.  Update returns the number of
        /// rows effected.
        /// <p/>
        /// The parameter object is generally used to supply the input
        /// data for the UPDATE values as well as the WHERE clause parameter(s).
        /// </summary>
        /// <param name="statementName">The name of the statement to execute.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns>The number of rows effected.</returns>
        int Update(string statementName, object parameterObject);

        /// <summary>
        /// Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        /// in the keyProperty parameter.  The value at each key will be the value of the property specified
        /// in the valueProperty parameter.  If valueProperty is null, the entire result object will be entered.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <returns>A IDictionary of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        IDictionary<K, V> QueryForDictionary<K, V>(string statementName, object parameterObject, string keyProperty, string valueProperty);


        /// <summary>
        ///  Executes the SQL and retuns all rows selected in a map that is keyed on the property named
        ///  in the keyProperty parameter.  The value at each key will be the entire result object.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <returns>A IDictionary of object containing the rows keyed by keyProperty.</returns>
        IDictionary<K, V> QueryForDictionary<K, V>(string statementName, object parameterObject, string keyProperty);

        /// <summary>
        /// Runs a query with a custom object that gets a chance to deal 
        /// with each row as it is processed.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="keyProperty">The property of the result object to be used as the key.</param>
        /// <param name="valueProperty">The property of the result object to be used as the value (or null)</param>
        /// <param name="rowDelegate">A delegate called once per row in the QueryForDictionary method></param>
        /// <returns>A IDictionary (Hashtable) of object containing the rows keyed by keyProperty.</returns>
        ///<exception cref="DataMapperException">If a transaction is not in progress, or the database throws an exception.</exception>
        IDictionary<K, V> QueryForDictionary<K, V>(string statementName, object parameterObject, string keyProperty, string valueProperty, DictionaryRowDelegate<K, V> rowDelegate);

        /// <summary>
        /// Executes a Sql SELECT statement that returns a single object of the type of the
        /// resultObject parameter.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="instanceObject">An object of the type to be returned.</param>
        /// <returns>The single result object populated with the result set data.</returns>
        T QueryForObject<T>(string statementName, object parameterObject, T instanceObject);

        /// <summary>
        /// Executes a Sql SELECT statement that returns that returns data 
        /// to populate a single object instance.
        /// <p/>
        /// The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns> The single result object populated with the result set data.</returns>
        T QueryForObject<T>(string statementName, object parameterObject);

        /// <summary>
        /// Executes a Sql SELECT statement that returns data to populate
        /// a number of result objects.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <returns>A List of result objects.</returns>
        IList<T> QueryForList<T>(string statementName, object parameterObject);

        /// <summary>
        /// Executes a Sql SELECT statement that returns data to populate
        /// a number of result objects.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="resultObject">An Ilist object used to hold the objects.</param>
        void QueryForList<T>(string statementName, object parameterObject, IList<T> resultObject);

        /// <summary>
        /// Runs a query for list with a custom object that gets a chance to deal 
        /// with each row as it is processed.
        /// <p/>
        ///  The parameter object is generally used to supply the input
        /// data for the WHERE clause parameter(s) of the SELECT statement.
        /// </summary>
        /// <param name="statementName">The name of the sql statement to execute.</param>
        /// <param name="parameterObject">The object used to set the parameters in the SQL.</param>
        /// <param name="rowDelegate"></param>
        /// <returns>A List of result objects.</returns>
        IList<T> QueryWithRowDelegate<T>(string statementName, object parameterObject, RowDelegate<T> rowDelegate);

        /// <summary>
        /// Executes a SQL SELECT statement that returns  data 
        /// to populate a DataTable.
        /// If a resultMap is specified, the column name will be the result property name.
        /// </summary>
        /// <param name="statementId">The statement id.</param>
        /// <param name="parameterObject">The parameter object.</param>
        /// <returns>A DataTable</returns>
        DataTable QueryForDataTable(string statementId, object parameterObject);
    }
}