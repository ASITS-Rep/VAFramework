
; VIS = window.VIS || {};
//java script function closer
; (function (VIS, $) {

    //Form Class function fullnamespace
    VIS.CustomerFormJs = function () {
        this.frame;
        this.windowNo;

        var $self = this; //scoped self pointe
        var $root, $okBtn, $cancelBtn;
        this.log = VIS.Logging.VLogger.getVLogger("CustomerFormJs");//init log Class

        //grid column list
        var arrListColumns = [];
        //grid Object
        var dGrid = null;
        var leftSideDiv = null;
        var leftSideBottomDiv = null;
        var rightSideDiv = null;

        var lbltitle = $('<label >Title</label>');
        var cmbtitle = $('<select   style="display: inline-block; width: 236px; height: 30px;">');

        var lblfName = $('<label >First Name</label>');
        var txtfName = $('<input type="text"  maxlength="100" class="vis-gc-vpanel-table-mandatory" style="display: inline-block; width: 236px; height: 30px;">');

        var lbllName = $('<label >Last Name</label>');
        var txtlName = $('<input type="text"  maxlength="100" class="vis-gc-vpanel-table-mandatory" style="display: inline-block; width: 236px; height: 30px;">');

        var lblgender= $('<label >Gender</label>');
        var cmbgender= $('<select  style="display: inline-block; width: 236px; height: 30px;" >');

        var lblDateOfBirth = $('<label >DateOfBirth</label>');
        var vdate = $('<input type="date" style="display: inline-block; width: 236px; height: 30px;">');

        var lblBottomMsg = $('<label >');

        /*
      initialize the design
      */
        function initializeComponent() {

            $root = $("<div style='width: 100%; height: 100%; background-color: white;'>");

            $okBtn = $("<input class='VIS_Pref_btn-2' style='   margin-right: 3px;height: 38px;' type='button' value='Save'>");
            $cancelBtn = $("<input class='VIS_Pref_btn-2' style='   margin-right: 15px ;width: 70px;height: 38px;' type='button' value='Clear'>");

            leftSideDiv = $("<div style='float: left; margin-left: 0px;height: 95%;width:20%;margin-top: 1px;position: relative; background-color: #F1F1F1;'>");
            leftSideBottomDiv = $("<div style='float: left; position: absolute; bottom: 0;height: 60px;width:100%; padding:0; margin:0; background-color:#F1F1F1;'>");

            bottumDiv = $("<div style='width: 100%; height: 60px; float: left; margin-bottom: 0px; background-color:#F1F1F1;'>");

            var tble = $("<table style='width: 100%;'>");
            //add table into div
            leftSideDiv.append(tble);


            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lbltitle.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(cmbtitle.css("display", "inline-block").css("width", "236px").css("height", "30px"));


            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lblfName.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(txtfName.css("display", "inline-block").css("width", "236px").css("height", "30px"));


            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lbllName.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(txtlName.css("display", "inline-block").css("width", "236px").css("height", "30px"));


            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lblgender.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(cmbgender.css("display", "inline-block").css("width", "236px").css("height", "30px"));

            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lblDateOfBirth.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(vdate.css("display", "inline-block").css("width", "236px").css("height", "30px"));

            leftSideBottomDiv.append($cancelBtn).append($okBtn);

            leftSideDiv.append(leftSideBottomDiv);
            //Right Side Div Declaration
            rightSideDiv = $("<div style='float: right; width: 70%; height: 95%;  margin: 0 auto !important; margin-top: 1px; border: 1px solid darkgray;'>");

            bottumDiv.append(lblBottomMsg.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));

            //add value to root
            $root.append(leftSideDiv).append(rightSideDiv).append(bottumDiv);


            $okBtn.on(VIS.Events.onTouchStartOrClick, function () {
                save();
            });

            $cancelBtn.on(VIS.Events.onTouchStartOrClick, function () {
                //if (confirm("wanna close this form?")) {
                //    $self.dispose();
                //}

                txtfName.val("");
                txtlName.val("");
                cmbtitle.prop('selectedIndex', -1);
                cmbgender.prop('selectedIndex', -1);
                vdate.val("");
                lblBottomMsg.text("Please Fill value to insert record.");
            });

            gettitleData();
            getgenderData();
        }

        /*
       Get data and fill grid selected record from grid
       */
        function loadGrid() {
            var data = [];
           
            $.ajax({
                url: VIS.Application.contextUrl + "VIS/Common/LoadCustomerData",
                data: { },
                async: false,
                success: function (result) {
                    result = JSON.parse(result);
                    if (result.length > 0) {
                        for (var i = 0; i < result.length; i++) {
                            var line = {};
                            line['id'] = result[i].Id;
                            line['title'] = result[i].Title;
                            line['firstname'] = result[i].FirstName;
                            line['lastname'] = result[i].LastName;
                            line['gender'] = result[i].Gender;
                            line['bdate'] = result[i].BDate;
                            line['recid'] = i + 1;
                            data.push(line);
                        }
                    }
                    dynInit(data);
                    
                },
                error: function (eror) {
                    console.log(eror);
                }
            });
            return data;
        };

    function dynInit(data) {

        if (dGrid != null) {
            dGrid.destroy();
            dGrid = null;
        }

        if (arrListColumns.length == 0) {
            arrListColumns.push({ field: "id", caption: VIS.Msg.translate(VIS.Env.getCtx(), "VIS_CustomerInformation2_ID"), sortable: true, size: '20%', min: 150, hidden: false });
            arrListColumns.push({ field: "title", caption: VIS.Msg.translate(VIS.Env.getCtx(), "VIS_Title"), sortable: true, size: '20%', min: 150, hidden: false });
            arrListColumns.push({ field: "firstname", caption: VIS.Msg.translate(VIS.Env.getCtx(), "VIS_FirstName"), sortable: true, size: '20%', min: 150, hidden: false });
            arrListColumns.push({ field: "lastname", caption: VIS.Msg.translate(VIS.Env.getCtx(), "VIS_LastName"), sortable: true, size: '20%', min: 150, hidden: false });
            arrListColumns.push({ field: "gender", caption: VIS.Msg.translate(VIS.Env.getCtx(), "VIS_Gender"), sortable: true, size: '20%', min: 150, hidden: false });
            arrListColumns.push({ field: "bdate", caption: VIS.Msg.getElement(VIS.Env.getCtx(), "VIS_BirthDate"), sortable: true, size: '150px', hidden: false, render: 'date' });
        }


        //encode data
        w2utils.encodeTags(data);

        dGrid = $(rightSideDiv).w2grid({
            name: "gridGenEmployeeForm" + $self.windowNo,
            recordHeight: 40,
            // show: { selectColumn: true },
            // multiSelect: true,
            columns: arrListColumns,
            records: data,
            onClick: function (event) {
                if (event.column == 4 && dGrid.records.length > 0) {
                    deleteRecord(event.recid);
                }
            }
        }); 
    }


        function gettitleData() {
            cmbtitle.empty();
            $.ajax({
                url: VIS.Application.contextUrl + "VIS/Common/GettitleData",
                success: function (result) {
                    result = JSON.parse(result);
                    if (result && result.length > 0) {
                        for (var i = 0; i < result.length; i++) {
                            cmbtitle.append(" <option value=" + result[i].ID + ">" + result[i].Value + "</option>");
                        }
                        cmbtitle.prop('selectedIndex', 0);
                    }
                },
                error: function (eror) {
                    console.log(eror);
                }

            });
        };


        function getgenderData() {
            cmbgender.empty();
            $.ajax({
                url: VIS.Application.contextUrl + "VIS/Common/getgenderData",
                success: function (result) {
                    result = JSON.parse(result);
                    if (result && result.length > 0) {
                        for (var i = 0; i < result.length; i++) {
                            cmbgender.append(" <option value=" + result[i].ID + ">" + result[i].Value + "</option>");
                        }
                        cmbgender.prop('selectedIndex', 0);
                    }
                },
                error: function (eror) {
                    console.log(eror);
                }

            });
        };

        function save() {
            alert("success");
            var seltitle = cmbtitle.find('option:selected').val();
            var selgender = cmbgender.find('option:selected').val();
            var selfname = txtfName.val();
            var sellname = txtlName.val();
            var seldate = vdate.val();
            var employeeId = 0;
            if (selfname.length <= 0 && sellname.length <= 0) {
                VIS.ADialog.info("FillMandatoryField!");
                $self.log.severe("EmployeenameMendatory");
                return;
            }
            if (seldate != "") {
                seldate = seldate.toString();
            }

            $.ajax({
                type: "POST",
                url: VIS.Application.contextUrl + "VIS/Common/Save",
                dataType: "json",
                data: {
                    'title': seltitle,
                    'fname': selfname,
                    'lname': sellname,
                    'gender': selgender,
                    'date': seldate
                },
                success: function (data) {
                    alert("success in");
                    var returnValue = data.result;
                    if (returnValue) {

                        lblBottomMsg.text("Record saved.");
                        loadGrid();
                        //$self.dispose();
                        return;
                    }
                    lblBottomMsg.text("Record not saved.");
                }
            });

        };

        this.Initialize = function () {
            //load by java script
            initializeComponent();
        }

        this.display = function () {
            loadGrid();
        }

        //Privilized function
        this.getRoot = function () {
            return $root;
        };

        /*
       dispose all object used in this form
       */
        this.disposeComponent = function () {
            $self = null;
            if ($root)
                $root.remove();
            $root = null;

            if (okBtn)
                okBtn.off(VIS.Events.onTouchStartOrClick);
            if (cancelBtn)
                cancelBtn.off(VIS.Events.onTouchStartOrClick);

            $busyDiv = okBtn = cancelBtn = null;

            arrListColumns = null;
            dGrid = null;
            leftSideDiv = null;
            leftSideBottomDiv = null;
            rightSideDiv = null;
            bottumDiv = null;

            lblName = null;
            txtName = null;

            lblDepartment = null;
            cmbDepartment = null;

            lblEmployeeGrade = null;
            cmbEmployeeGrade = null;

            lblDateOfBirth = null;
            vdate = null;
            lblBottomMsg = null;

            this.getRoot = null;
            this.disposeComponent = null;


        };

    };

    //Must Implement with same parameter
    VIS.CustomerFormJs.prototype.init = function (windowNo, frame) {
        //Assign to this Varable
        this.frame = frame;
        this.windowNo = windowNo;
        var obj = this.Initialize();
        this.frame.getContentGrid().append(this.getRoot());
        this.display();
    };

    //Must implement dispose
    VIS.CustomerFormJs.prototype.dispose = function () {
        /*CleanUp Code */
        //dispose this component
        this.disposeComponent();

        //call frame dispose function
        if (this.frame)
            this.frame.dispose();
        this.frame = null;
    };

})(VIS, jQuery);