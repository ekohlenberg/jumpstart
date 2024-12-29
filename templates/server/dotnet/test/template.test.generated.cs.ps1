﻿@using System;
@using System.Collections.Generic;
@using System.Linq;
@using System.Threading.Tasks;
@using @Model.Namespace;

namespace @Model.Namespace
{
    public partial class @Model.DomainObjTest : BaseTest
    {
        public static void testInsert()
        {
            var @Model.DomainVar = new @Model.DomainObj();

            @foreach (var column in Model.Columns)
            {
                if (column.ColumnName.EndsWith("id"))
                {
                    if (!string.IsNullOrEmpty(column.FkObject))
                    {
                        <text>
                            @Model.DomainVar.@column.ColumnName = BaseTest.getLastId("@column.FkObject");
                        </text>
                    }
                }
                else
                {
                    var testDataSet = "random";
                    if (!string.IsNullOrEmpty(column.TestDataSet))
                    {
                        testDataSet = column.TestDataSet;
                    }
                    <text>
                        @Model.DomainVar.@column.ColumnName = (@Model.TypeMapping[column.DataType]) BaseTest.getTestData(@Model.DomainVar, "@column.DataType", TestDataType.@testDataSet);
                    </text>
                }
            }
            <text>
                Console.WriteLine("Testing @Model.DomainObjLogic insert: " + @Model.DomainVar.ToString());
                @Model.DomainObjLogic.insert(@Model.DomainVar);
                BaseTest.addLastId("@Model.DomainObj", @Model.DomainVar.Id);
            </text>
        }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("@Model.DomainObj");
            var @Model.DomainVar = @Model.DomainObjLogic.get(lastId);

            @foreach (var column in Model.Columns)
            {
                if (column.ColumnName.EndsWith("id"))
                {
                    if (!string.IsNullOrEmpty(column.FkObject))
                    {
                        <text>
                            @Model.DomainVar.@column.ColumnName = BaseTest.getLastId("@column.FkObject");
                        </text>
                    }
                }
                else
                {
                    var testDataSet = "random";
                    if (!string.IsNullOrEmpty(column.TestDataSet))
                    {
                        testDataSet = column.TestDataSet;
                    }
                    <text>
                        @Model.DomainVar.@column.ColumnName = (@Model.TypeMapping[column.DataType]) BaseTest.getTestData(@Model.DomainVar, "@column.DataType", TestDataType.@testDataSet);
                    </text>
                }
            }
            <text>
                Console.WriteLine("Testing @Model.DomainObjLogic update: " + @Model.DomainVar.ToString());
                @Model.DomainObjLogic.update(lastId, @Model.DomainVar);
            </text>
        }
    }
}
