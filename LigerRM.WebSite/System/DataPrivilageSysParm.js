var ruleDataOptions = {
    width: 200,
    url: "../handler/select.ashx?view=CF_Role&idfield=RoleID&textfield=RoleName",
    isMultiSelect: true, split: ','
};

var userDataOptions = {
    width: 200,
    url: "../handler/select.ashx?view=CF_User&idfield=UserID&textfield=Title"
};
var deptDataOptions = {
    width: 200,
    url: "../handler/select.ashx?view=CF_Department&idfield=DeptID&textfield=DeptName"
};
var employeeDataOptions = {
    width: 200,
    url: "../handler/select.ashx?view=Employees&idfield=EmployeeID&textfield=Title"
};
var supplierDataOptions = {
    width: 200,
    url: "../handler/select.ashx?view=Suppliers&idfield=SupplierID&textfield=CompanyName"
};

var SysParms = [
    { name: '{CurrentUserID}', display: '{当前用户}', type: 'int',
        editor: { type: 'combobox', options: userDataOptions }
    },
    { name: '{CurrentRoleID}', display: '{当前角色}', type: 'int',
        editor: { type: 'combobox', options: ruleDataOptions }
    },
    { name: '{CurrentDeptID}', display: '{当前部门}', type: 'int',
        editor: { type: 'combobox', options: deptDataOptions }
    },
    { name: '{CurrentEmployeeID}', display: '{当前员工}', type: 'int',
        editor: { type: 'combobox', options: employeeDataOptions }
    },
    { name: '{CurrentAreaIDs}', display: '{当前区域}', type: 'string',
        editor: { type: 'text', options: supplierDataOptions }
    },
        { name: '{CurrentCarveIDs}', display: '{关联制章单位}', type: 'string',
            editor: { type: 'text', options: supplierDataOptions }
        }
];

function getFields(view)
{
    for (var i = 0, l = DbViews.length; i < l; i++)
    {
        var v = DbViews[i];

        if (v.name == view)
        {
            var fields = [];
            $(v.columns).each(function ()
            {
                fields.push({
                    name: this.name,
                    display: this.display,
                    type: this.type,
                    editor: getFieldEditor(view, this.name)
                });
            });
            $(SysParms).each(function ()
            {
                fields.push({
                    name: this.name,
                    display: this.display,
                    type: this.type,
                    editor: this.editor
                });
            });
            return fields;
        }
    }
    return SysParms;
}

var fieldEditors = {};
fieldEditors['Orders'] = {
    'ShipCity': { type: 'combobox', 
        options: {
            width: 200,
            url: "../handler/select.ashx?view=Orders&idfield=ShipCity&textfield=ShipCity&distinct=true"
        }
    }
};
fieldEditors['Products'] = {
    'CategoryID': { type: 'combobox', 
        options: {
			width: 200,
			url: "../handler/select.ashx?view=Categories&idfield=CategoryID&textfield=CategoryName",
			isMultiSelect: true, split: ','
		}
    }
};

function getFieldEditor(view, field)
{
    if(fieldEditors[view] && fieldEditors[view][field])
        return fieldEditors[view][field];
    return null;
}