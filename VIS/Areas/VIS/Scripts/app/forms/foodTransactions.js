; VIS = window.VIS || {};
//java script function closer
; (function (VIS, $) {

    //Form Class function fullnamespace
    VIS.ASI03_FoodTransactions = function () {
        this.frame;
        this.windowNo;

        var $self = this; //scoped self pointe
        var $root, $okBtn, $cancelBtn;
        this.log = VIS.Logging.VLogger.getVLogger("ASI03_FoodTransactions");//init log Class

        //grid column list
        var arrListColumns = [];
        //grid Object
        var dGrid = null;
        var leftSideDiv = null;
        var leftSideBottomDiv = null;
        var rightSideDiv = null;

        var lblproduct = $('<label >Product</label>');
        var cmbproduct = $('<select   style="display: inline-block; width: 236px; height: 30px;">');

        var lblamount = $('<label >Amount</label>');
        var txtamount = $('<input type="number"  maxlength="100" class="vis-gc-vpanel-table-mandatory" style="display: inline-block; width: 236px; height: 30px;">');

        var lblunit = $('<label >Unit</label>');
        var cmbunit = $('<select   style="display: inline-block; width: 236px; height: 30px;">');

        var lblfromstorage = $('<label >From Storage</label>');
        var cmbfromstorage = $('<select  style="display: inline-block; width: 236px; height: 30px;" >');

        var lbltostorage = $('<label >To Storage</label>');
        var cmbtostorage = $('<select  style="display: inline-block; width: 236px; height: 30px;" >');

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
            td.append(lblproduct.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(cmbproduct.css("display", "inline-block").css("width", "236px").css("height", "30px"));


            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lblamount.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(txtamount.css("display", "inline-block").css("width", "236px").css("height", "30px"));


            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lblunit.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(cmbunit.css("display", "inline-block").css("width", "236px").css("height", "30px"));


            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lblfromstorage.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(cmbfromstorage.css("display", "inline-block").css("width", "236px").css("height", "30px"));

            var tr = $("<tr>");
            var td = $("<td style='padding: 4px 15px 2px;'>");

            tble.append(tr);
            tr.append(td);
            td.append(lbltostorage.css("display", "inline-block").addClass("VIS_Pref_Label_Font"));
            tr = $("<tr>");
            td = $("<td style='padding: 0px 15px 0px;'>");
            tble.append(tr);
            tr.append(td);
            td.append(cmbtostorage.css("display", "inline-block").css("width", "236px").css("height", "30px"));

            leftSideBottomDiv.append($cancelBtn).append($okBtn);

            leftSideDiv.append(leftSideBottomDiv);
            //Right Side Div Declaration
            rightSideDiv = $("<div style='float: right; width: 80%; height: 95%;  margin: 0 auto !important; margin-top: 1px; border: 1px solid darkgray;'>");

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

                cmbfromstorage.val(0);
                cmbtostorage.val(0);
                cmbproduct.prop('selectedIndex', 0);
                cmbunit.prop('selectedIndex', 0);
                txtamount.val(0);
                lblBottomMsg.text("Please Fill value to insert record.");
            });

            getSelectListsData();
        }

        /*
       Get data and fill grid selected record from grid
       */
        function loadGrid() {
            var data = [];

            $.ajax({
                url: VIS.Application.contextUrl + "VIS/Home/GetProductsTrns",
                data: {},
                async: false,
                success: function (result) {
                    result = JSON.parse(result.data);
                    let productTrns = result.listProductsTrns;
                    if (productTrns.length > 0) {
                        for (var i = 0; i < productTrns.length; i++) {
                            var line = {};
                            line['id'] = productTrns[i].ASI03_ProductTransaction_ID;
                            line['product'] = productTrns[i].ProductName;
                            line['amount'] = productTrns[i].ASI03_ProductAmount;
                            line['unit'] = productTrns[i].Unit;
                            line['fromstorage'] = productTrns[i].FromStorageName;
                            line['tostorage'] = productTrns[i].ToStorageName;
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
                if (w2ui.hasOwnProperty('layout')) {
                    w2ui['layout'].destroy();
                }
                if (w2ui.hasOwnProperty('grid')) {
                    w2ui['grid'].destroy();
                }
                if (w2ui.hasOwnProperty('form')) {
                    w2ui['form'].destroy();
                }
                dGrid.destroy();
                dGrid = null;
            }

            if (arrListColumns.length == 0) {
                arrListColumns.push({ field: "product", caption: "Product", sortable: true, size: '20%', min: 150, hidden: false });
                arrListColumns.push({ field: "amount", caption: VIS.Msg.translate(VIS.Env.getCtx(), "ASI03_ProductAmount"), sortable: true, size: '10%', min: 150, hidden: false });
                arrListColumns.push({ field: "unit", caption: "Unit", sortable: false, size: '10%', min: 150, hidden: false });
                arrListColumns.push({ field: "fromstorage", caption: VIS.Msg.translate(VIS.Env.getCtx(), "ASI03_FromStorage"), sortable: true, size: '20%', min: 150, hidden: false });
                arrListColumns.push({ field: "tostorage", caption: VIS.Msg.getElement(VIS.Env.getCtx(), "ASI03_ToStorage"), sortable: true, size: '20%', hidden: false });
                arrListColumns.push({
                    field: "Delete", caption: VIS.Msg.translate(VIS.Env.getCtx(), "Delete"), sortable: true, size: '10%', min: 150, hidden: false,
                    render: function () { return '<div><img src="' + VIS.Application.contextUrl + 'Areas/VIS/Images/base/Delete24.png" alt="Delete record" title="Delete record" style="opacity: 1;"></div>'; }
                });
                arrListColumns.push({ field: "id", caption: VIS.Msg.translate(VIS.Env.getCtx(), "ASI03_ProductTransaction_ID"), sortable: true, size: '20%', min: 150, hidden: true });
            }


            //encode data
            w2utils.encodeTags(data);

            
            var config = {
                layout: {
                    name: 'layout',
                    padding: 4,
                    panels: [
                        { type: 'left', size: '75%', resizable: true, minSize: 300 },
                        { type: 'main', minSize: 300 }
                    ]
                },
                grid: {
                    name: 'grid',
                    show: {
                        toolbar: true,
                        lineNumbers: true
                    },
                    recordHeight: 40,
                    // show: { selectColumn: true },
                    // multiSelect: true,
                    columns: arrListColumns,
                    records: data,
                    onClick: function (event) {
                        if (event.column == 6 && dGrid.records.length > 0) {
                            deleteRecord(event.recid);
                        }
                    },
                    onDblClick: function (event) {
                        var grid = this;
                        var form = w2ui.form;
                        event.onComplete = function () {
                            var sel = grid.getSelection();
                            console.log(sel);
                            if (sel.length == 1) {
                                form.recid = sel[0];
                                form.record = $.extend(true, {}, grid.get(sel[0]));
                                form.refresh();
                            } else {
                                form.clear();
                            }
                        }
                    }
                },
                form: {
                    header: 'Show Record',
                    name: 'form',
                    fields: [
                        { name: 'id', type: 'text', html: { caption: 'ID', attr: 'size="20" readonly' } },
                        { name: 'product', type: 'text', html: { caption: 'Product', attr: 'size="20" readonly' } },
                        { name: 'amount', type: 'text', html: { caption: 'Amount', attr: 'size="20" readonly' } },
                        { name: 'unit', type: 'text', html: { caption: 'Unit', attr: 'size="20" readonly' } },
                        { name: 'fromstorage', type: 'text', html: { caption: 'From Storage', attr: 'size="20" readonly' } },
                        { name: 'tostorage', type: 'text', html: { caption: 'To Storage', attr: 'size="20" readonly' } }
                    ],
                    actions: {
                        Reset: function () {
                            this.clear();
                        }
                    }
                }
            }
            dGrid = $(rightSideDiv).w2layout(config.layout);
            w2ui.layout.html('left', $().w2grid(config.grid));
            w2ui.layout.html('main', $().w2form(config.form));
            //$(function () {
            //    // initialization
                
            //});
                /*w2grid();*/
        }

        

        function getSelectListsData() {
            $.ajax({
                url: VIS.Application.contextUrl + 'Home/GetSelectLists',
                data: {},
                type: 'GET',
                datatype: 'json',
                success: function (result) {
                    result = JSON.parse(result.data)
                    let productsList = result.ProductsLists;
                    let unitsList = result.UnitsLists;
                    let storageList = result.FromStorageLists;
                    if (productsList.length > 0) {
                        cmbproduct.append('<option value="' + 0 + '">' + "Select Product" + '</option>');
                        for (var i = 0; i < productsList.length; i++) {
                            cmbproduct.append('<option value="' + productsList[i].ASI03_Products_ID + '">' + productsList[i].ProductName + '</option>')
                        }
                    }
                    if (unitsList.length > 0) {
                        cmbunit.append('<option value="' + 0 + '">' + "Select Unit" + '</option>');
                        for (var i = 0; i < unitsList.length; i++) {
                            cmbunit.append('<option value="' + unitsList[i].C_UOM_ID + '">' + unitsList[i].Unit + '</option>')
                        }
                    }
                    if (storageList.length > 0) {
                        cmbfromstorage.append('<option value="' + 0 + '">' + "Select Unit" + '</option>');
                        cmbtostorage.append('<option value="' + 0 + '">' + "Select Unit" + '</option>');
                        for (var i = 0; i < storageList.length; i++) {
                            cmbfromstorage.append('<option value="' + storageList[i].ASI03_Warehouse_ID + '">' + storageList[i].FromStorageName + '</option>')
                            cmbtostorage.append('<option value="' + storageList[i].ASI03_Warehouse_ID + '">' + storageList[i].FromStorageName + '</option>')
                        }
                    }
                },
                error: function () {
                    console.log('Faild')
                }
            });
        }

        function save() {
            var selprod = cmbproduct.find('option:selected').val();
            var selunit = cmbunit.find('option:selected').val();
            var inamount = txtamount.val();
            var selfromstorage = cmbfromstorage.find('option:selected').val();
            var seltostorage = cmbtostorage.find('option:selected').val();
            if (selprod.length <= 0 || selfromstorage.length <= 0 || seltostorage.length <= 0 || selunit.length <= 0 || inamount <= 0) {
                VIS.ADialog.info("FillMandatoryFields!");
                $self.log.severe("TrnsFieldsMandatory");
                return;
            }

            $.ajax({
                type: "POST",
                url: VIS.Application.contextUrl + "VIS/Home/AddTrns",
                dataType: "html",
                data: {
                    prodId: selprod,
                    amount: inamount,
                    fromStorage: selfromstorage,
                    toStorage: seltostorage,
                    unitId: selunit
                },
                success: function (result) {
                    if (result) {
                        lblBottomMsg.text("Record saved.");
                        loadGrid();
                        cmbfromstorage.val(0);
                        cmbtostorage.val(0);
                        cmbproduct.prop('selectedIndex', 0);
                        cmbunit.prop('selectedIndex', 0);
                        txtamount.val(0);
                        
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

            if (w2ui.hasOwnProperty('layout')) {
                w2ui['layout'].destroy();
            }
            if (w2ui.hasOwnProperty('grid')) {
                w2ui['grid'].destroy();
            }
            if (w2ui.hasOwnProperty('form')) {
                w2ui['form'].destroy();
            }

            $busyDiv = okBtn = cancelBtn = null;

            arrListColumns = null;
            dGrid = null;
            leftSideDiv = null;
            leftSideBottomDiv = null;
            rightSideDiv = null;
            bottumDiv = null;

            lblproduct = null;
            cmbproduct = null;

            lblamount = null;
            txtamount = null;

            lblunit = null;
            cmbunit = null;

            lblfromstorage = null;
            cmbfromstorage = null;

            lbltostorage = null;
            cmbtostorage = null;

            lblBottomMsg = null;

            this.getRoot = null;
            this.disposeComponent = null;


        };

    };

    //Must Implement with same parameter
    VIS.ASI03_FoodTransactions.prototype.init = function (windowNo, frame) {
        //Assign to this Varable
        this.frame = frame;
        this.windowNo = windowNo;
        var obj = this.Initialize();
        this.frame.getContentGrid().append(this.getRoot());
        this.display();
    };

    //Must implement dispose
    VIS.ASI03_FoodTransactions.prototype.dispose = function () {
        /*CleanUp Code */
        //dispose this component
        this.disposeComponent();

        //call frame dispose function
        if (this.frame)
            this.frame.dispose();
        this.frame = null;
    };

})(VIS, jQuery);