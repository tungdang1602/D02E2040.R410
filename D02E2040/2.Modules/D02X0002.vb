Imports System.Text
''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>

Module D02X0002

    Public Sub LoadFormatsNew()
        '#------------------------------------------------------
        '#CreateUser: Trần Thị Ái Trâm
        '#CreateDate: 06/10/2009
        '#Description: Format so theo D91

        Const Number2 As String = "#,##0.00"
        Const Number4 As String = "#,##0.0000" 'dung Format ty le thue
        Const Number0 As String = "#,##0"
        Dim sSQL As String = "Exec D91P9300 "
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        With D02Format
            If dt.Rows.Count > 0 Then
                .ExchangeRate = InsertFormat(dt.Rows(0).Item("ExchangeRateDecimals"))
                .DecimalPlaces = InsertFormat(dt.Rows(0).Item("DecimalPlaces"))
                .MyOriginal = .DecimalPlaces
                .D90_Converted = InsertFormat(dt.Rows(0).Item("D90_ConvertedDecimals"))
                .D07_Quantity = InsertFormat(dt.Rows(0).Item("D07_QuantityDecimals"))
                .D07_UnitCost = InsertFormat(dt.Rows(0).Item("D07_UnitCostDecimals"))
                .D08_Quantity = InsertFormat(dt.Rows(0).Item("D08_QuantityDecimals"))
                .D08_UnitCost = InsertFormat(dt.Rows(0).Item("D08_UnitCostDecimals"))
                .D08_Ratio = InsertFormat(dt.Rows(0).Item("D08_RatioDecimals"))
                .D90_ConvertedDecimals = CInt(dt.Rows(0).Item("D90_ConvertedDecimals"))
                .BaseCurrencyID = (IIf(IsDBNull(dt.Rows(0).Item("BaseCurrencyID").ToString), "", dt.Rows(0).Item("BaseCurrencyID").ToString)).ToString

                '.BOMQty = InsertFormat(dt.Rows(0).Item("BOMQtyDecimals"))
                '.BOMPrice = InsertFormat(dt.Rows(0).Item("BOMPriceDecimals"))
                '.BOMAmt = InsertFormat(dt.Rows(0).Item("BOMAmtDecimals"))
            Else
                .ExchangeRate = Number2
                .D90_Converted = Number2
                .D07_Quantity = Number2
                .D07_UnitCost = Number2
                .D08_Quantity = Number2
                .D08_UnitCost = Number2
                .D08_Ratio = Number2
                .D90_ConvertedDecimals = 0
                .DecimalSeparator = ","
                .ThousandSeparator = "."
                .BaseCurrencyID = ""
                '.BOMQty = Number2
                '.BOMPrice = Number2
                '.BOMAmt = Number2
            End If
            .DefaultNumber2 = Number2
            .DefaultNumber4 = Number4
            .DefaultNumber0 = Number0
        End With
    End Sub

    Public Function InsertFormat(ByVal ONumber As Object) As String
        Dim iNumber As Int16 = Convert.ToInt16(ONumber)
        Dim sRet As String = "#,##0"
        If iNumber = 0 Then
        Else
            sRet &= "." & Strings.StrDup(iNumber, "0")
        End If
        Return sRet
    End Function

    'Câu đổ nguồn chung cho SubReport
    Public Function SQLSubReport(ByVal sDivisionID As String) As String
        Dim sSQL As String = ""
        sSQL = "Select * From D91V0016" & vbCrLf
        sSQL &= "Where DivisionID = " & SQLString(sDivisionID)
        Return sSQL
    End Function

    Public Sub InsertD02T5558(ByVal sVoucherID As String, ByVal sOldVoucherNo As String, ByVal sNewVoucherNo As String)
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D02T5558(")
        sSQL.Append("BatchID, OldVoucherNo, NewVoucherNo, CreateUserID, CreateDate, ")
        sSQL.Append("TranMonth, TranYear, DivisionID")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(sVoucherID) & COMMA) 'VoucherID, varchar[20], NOT NULL
        sSQL.Append(SQLString(sOldVoucherNo) & COMMA) 'OldVoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLString(sNewVoucherNo) & COMMA) 'NewVoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, tinyint, NOT NULL
        sSQL.Append(SQLNumber(giTranYear)) 'TranYear, int, NOT NULL
        sSQL.Append(COMMA & SQLString(gsDivisionID))
        sSQL.Append(")")
        ExecuteSQLNoTransaction(sSQL.ToString)
    End Sub


    Public Function ComboValue(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.Text = "" Or tdbc.SelectedValue Is Nothing Then Return ""
        Return tdbc.SelectedValue.ToString
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD02P7777
    '# Created User: NGOCTHOAI
    '# Created Date: 04/07/2017 08:48:06
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD02P7777(sFormID As String, sTableName As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Thuc thi D02P7777 " & vbCrLf)
        sSQL &= "Exec D02P7777 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[50], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[50], NOT NULL
        sSQL &= SQLString(sFormID) & COMMA 'FormID, varchar[50], NOT NULL
        sSQL &= SQLString(sTableName) 'TableName, varchar[250], NOT NULL
        Return sSQL
    End Function



   End Module
