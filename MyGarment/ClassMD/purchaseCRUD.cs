﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace MyGarment.ClassMD
{
    class purchaseCRUD
    {
        private MySqlCommand strQuery = null;


        public DataSet getData()
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                Connection Conn = new Connection();
                Conn.Konek();
                strQuery = new MySqlCommand();
                strQuery.Connection = Conn.Conn;
                strQuery.CommandType = CommandType.Text;
                strQuery.CommandText = "PONO,DATE,OFFICER,GDIV,CUSTVENDID,DELIVERYTONAME,DELIVERYTOADDRESS,"+
                    "TERMOFPAYMENT,APPROVE,APPROVEDATE,APPROVEBY,CLOSE,REMARKS,ACKNOWLEDGEMENT,ACKNOWLEDGEMENTDATE" +
                    ",ACKNOWLEDGEMENTBY,TOTALAMOUNT,TOTALDISCOUNT,TOTALPPN,CURRENCYID,CHECKED,CHECKDATE,CHECKBY,NOTE " +
                    ",ETA,REFERTO,TOTALPAID,REVISE,REVISEDATE,REVISEBY,NONREQ,TOTALUPCHARGES,ETD,DUEDATE,SHIPMODA,REVISEDUEDATE" +
                    " FROM tblpurchase";
                MySqlDataAdapter data = new MySqlDataAdapter(strQuery);
                data.Fill(ds, "tblpurchase");
                Conn.Putus();
            }
            catch
            {
            }
            return ds;
        }

        public DataSet getData(string PONO)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                Connection Conn = new Connection();
                Conn.Konek();
                strQuery = new MySqlCommand();
                strQuery.Connection = Conn.Conn;
                strQuery.CommandType = CommandType.Text;
                strQuery.CommandText = "PONO,DATE,OFFICER,GDIV,CUSTVENDID,DELIVERYTONAME,DELIVERYTOADDRESS," +
                    "TERMOFPAYMENT,APPROVE,APPROVEDATE,APPROVEBY,CLOSE,REMARKS,ACKNOWLEDGEMENT,ACKNOWLEDGEMENTDATE" +
                    ",ACKNOWLEDGEMENTBY,TOTALAMOUNT,TOTALDISCOUNT,TOTALPPN,CURRENCYID,CHECKED,CHECKDATE,CHECKBY,NOTE " +
                    ",ETA,REFERTO,TOTALPAID,REVISE,REVISEDATE,REVISEBY,NONREQ,TOTALUPCHARGES,ETD,DUEDATE,SHIPMODA,REVISEDUEDATE" +
                        " FROM tblpurchase WHERE PONO LIKE @PONO";
                strQuery.Parameters.AddWithValue("@PONO", "%" + PONO + "%");
                MySqlDataAdapter data = new MySqlDataAdapter(strQuery);
                data.Fill(ds, "tblpurchase");
                Conn.Putus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet getData(string PONO, string TYPEID, string STAT, string OFFICER, string CUSTVENDCODE, int APPROVE)
        {
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                Connection Conn = new Connection();
                Conn.Konek();
                strQuery = new MySqlCommand();
                strQuery.Connection = Conn.Conn;
                strQuery.CommandType = CommandType.Text;
                strQuery.CommandText = "PONO,DATE,OFFICER,GDIV,CUSTVENDID,DELIVERYTONAME,DELIVERYTOADDRESS,"+
                    "TERMOFPAYMENT,APPROVE,APPROVEDATE,APPROVEBY,CLOSE,REMARKS,ACKNOWLEDGEMENT,ACKNOWLEDGEMENTDATE" +
                    ",ACKNOWLEDGEMENTBY,TOTALAMOUNT,TOTALDISCOUNT,TOTALPPN,CURRENCYID,CHECKED,CHECKDATE,CHECKBY,NOTE " +
                    ",ETA,REFERTO,TOTALPAID,REVISE,REVISEDATE,REVISEBY,NONREQ,TOTALUPCHARGES,ETD,DUEDATE,SHIPMODA,REVISEDUEDATE" +
                        " FROM tblpurchase WHERE COSTINGNO LIKE @COSTINGNO AND TYPEID LIKE @TYPEID AND IFNULL(STAT,1) LIKE @STAT " +
                        "AND IFNULL(OFFICER,1) LIKE @OFFICER AND CUSTVENDCODE LIKE @CUSTVENDCODE AND APPROVE LIKE @APPROVE";
                strQuery.Parameters.AddWithValue("@COSTINGNO", "%" + PONO + "%");
                strQuery.Parameters.AddWithValue("@TYPEID", "%" + TYPEID + "%");
                strQuery.Parameters.AddWithValue("@STAT", "%" + STAT + "%");
                strQuery.Parameters.AddWithValue("@OFFICER", "%" + OFFICER + "%");
                strQuery.Parameters.AddWithValue("@CUSTVENDCODE", "%" + CUSTVENDCODE + "%");
                strQuery.Parameters.AddWithValue("@APPROVE", "%" + APPROVE + "%");
                MySqlDataAdapter data = new MySqlDataAdapter(strQuery);
                data.Fill(ds, "tblpurchase");
                Conn.Putus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
        public bool insertData(costing k)
        {
            bool stat = false;
            try
            {
                Connection ConnG = new Connection();
                ConnG.Konek();
                strQuery = new MySqlCommand();
                strQuery.Connection = ConnG.Conn;
                strQuery.CommandType = CommandType.Text;

                strQuery.CommandText = "INSERT INTO tblpurchase VALUES(@COSTINGNO,@QTYORDER,@GDIV,@TYPEID,@CATEGORYID,@STAT,@DATE,@OFFICER," +
                        "@ITEMSID,@CUSTVENDCODE,@APPROVE,@APPROVEDATE,@APPROVEBY,@COGS,@MARGIN,@MARGINVALUE,@NETTPRICE," +
                        "@DISCOUNT,@DISCOUNTVALUE,@PPN,@PPNVALUE,@SELLINGPRICE,@KURS,@VALUEIN,@REVISE,@REVISEDATE,@REVISEBY)";
                strQuery.Parameters.AddWithValue("@COSTINGNO", k.COSTINGNO);
                strQuery.Parameters.AddWithValue("@QTYORDER", k.QTYORDER);
                strQuery.Parameters.AddWithValue("@GDIV", k.GDIV);
                strQuery.Parameters.AddWithValue("@TYPEID", k.TYPEID);
                strQuery.Parameters.AddWithValue("@CATEGORYID", k.CATEGORYID);
                strQuery.Parameters.AddWithValue("@STAT", k.STAT);
                strQuery.Parameters.AddWithValue("@DATE", k.DATE);
                strQuery.Parameters.AddWithValue("@OFFICER", k.OFFICER);
                strQuery.Parameters.AddWithValue("@ITEMSID", k.ITEMSID);
                strQuery.Parameters.AddWithValue("@CUSTVENDCODE", k.CUSTVENDCODE);
                strQuery.Parameters.AddWithValue("@APPROVE", k.APPROVE);
                strQuery.Parameters.AddWithValue("@APPROVEDATE", k.APPROVEDATE);
                strQuery.Parameters.AddWithValue("@APPROVEBY", k.APPROVEBY);
                strQuery.Parameters.AddWithValue("@COGS", k.COGS);
                strQuery.Parameters.AddWithValue("@MARGIN", k.MARGIN);
                strQuery.Parameters.AddWithValue("@MARGINVALUE", k.MARGINVALUE);
                strQuery.Parameters.AddWithValue("@NETTPRICE", k.NETTPRICE);
                strQuery.Parameters.AddWithValue("@DISCOUNT", k.DISCOUNT);
                strQuery.Parameters.AddWithValue("@DISCOUNTVALUE", k.DISCOUNTVALUE);
                strQuery.Parameters.AddWithValue("@PPN", k.PPN);
                strQuery.Parameters.AddWithValue("@PPNVALUE", k.PPNVALUE);
                strQuery.Parameters.AddWithValue("@SELLINGPRICE", k.SELLINGPRICE);
                strQuery.Parameters.AddWithValue("@KURS", k.KURS);
                strQuery.Parameters.AddWithValue("@VALUEIN", k.VALUEIN);
                strQuery.Parameters.AddWithValue("@REVISE", k.REVISE);
                strQuery.Parameters.AddWithValue("@REVISEDATE", k.REVISEDATE);
                strQuery.Parameters.AddWithValue("@REVISEBY", k.REVISEBY);

                strQuery.ExecuteNonQuery();
                stat = true;
                ConnG.Putus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stat;
        }
        public bool updateData(costing k)
        {
            bool stat = false;
            try
            {
                Connection ConnG = new Connection();
                ConnG.Konek();
                strQuery = new MySqlCommand();
                strQuery.Connection = ConnG.Conn;
                strQuery.CommandType = CommandType.Text;
                strQuery.CommandText = "UPDATE tblpurchase SET QTYORDER=@QTYORDER,GDIV=@GDIV,TYPEID=@TYPEID,CATEGORYID=@CATEGORYID,STAT=@STAT,DATE=@DATE,OFFICER=@OFFICER," +
                        "ITEMSID=@ITEMSID,CUSTVENDCODE=@CUSTVENDCODE,APPROVE=@APPROVE,APPROVEDATE=@APPROVEDATE,APPROVEBY=@APPROVEBY,COGS=@COGS,MARGIN=@MARGIN,MARGINVALUE=@MARGINVALUE,NETTPRICE=@NETTPRICE," +
                        "DISCOUNT=@DISCOUNT,DISCOUNTVALUE=@DISCOUNTVALUE,PPN=@PPN,PPNVALUE=@PPNVALUE,SELLINGPRICE=@SELLINGPRICE,KURS=@KURS,VALUEIN=@VALUEIN,REVISE=@REVISE,REVISEDATE=@REVISEDATE,REVISEBY=@REVISEBY" +
                        " WHERE COSTINGNO=@COSTINGNO";
                strQuery.Parameters.AddWithValue("@COSTINGNO", k.COSTINGNO);
                strQuery.Parameters.AddWithValue("@QTYORDER", k.QTYORDER);
                strQuery.Parameters.AddWithValue("@GDIV", k.GDIV);
                strQuery.Parameters.AddWithValue("@TYPEID", k.TYPEID);
                strQuery.Parameters.AddWithValue("@CATEGORYID", k.CATEGORYID);
                strQuery.Parameters.AddWithValue("@STAT", k.STAT);
                strQuery.Parameters.AddWithValue("@DATE", k.DATE);
                strQuery.Parameters.AddWithValue("@OFFICER", k.OFFICER);
                strQuery.Parameters.AddWithValue("@ITEMSID", k.ITEMSID);
                strQuery.Parameters.AddWithValue("@CUSTVENDCODE", k.CUSTVENDCODE);
                strQuery.Parameters.AddWithValue("@APPROVE", k.APPROVE);
                strQuery.Parameters.AddWithValue("@APPROVEDATE", k.APPROVEDATE);
                strQuery.Parameters.AddWithValue("@APPROVEBY", k.APPROVEBY);
                strQuery.Parameters.AddWithValue("@COGS", k.COGS);
                strQuery.Parameters.AddWithValue("@MARGIN", k.MARGIN);
                strQuery.Parameters.AddWithValue("@MARGINVALUE", k.MARGINVALUE);
                strQuery.Parameters.AddWithValue("@NETTPRICE", k.NETTPRICE);
                strQuery.Parameters.AddWithValue("@DISCOUNT", k.DISCOUNT);
                strQuery.Parameters.AddWithValue("@DISCOUNTVALUE", k.DISCOUNTVALUE);
                strQuery.Parameters.AddWithValue("@PPN", k.PPN);
                strQuery.Parameters.AddWithValue("@PPNVALUE", k.PPNVALUE);
                strQuery.Parameters.AddWithValue("@SELLINGPRICE", k.SELLINGPRICE);
                strQuery.Parameters.AddWithValue("@KURS", k.KURS);
                strQuery.Parameters.AddWithValue("@VALUEIN", k.VALUEIN);
                strQuery.Parameters.AddWithValue("@REVISE", k.REVISE);
                strQuery.Parameters.AddWithValue("@REVISEDATE", k.REVISEDATE);
                strQuery.Parameters.AddWithValue("@REVISEBY", k.REVISEBY);
                strQuery.ExecuteNonQuery();

                ConnG.Putus();
                stat = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stat;
        }
        public bool deleteData(string costID)
        {
            bool stat = false;
            try
            {
                Connection ConnG = new Connection();
                ConnG.Konek();
                strQuery = new MySqlCommand();
                strQuery.Connection = ConnG.Conn;
                strQuery.CommandType = CommandType.Text;
                strQuery.CommandText = "DELETE FROM tblpurchase WHERE COSTINGNO = @CostID";
                strQuery.Parameters.AddWithValue("@CostID", costID);
                strQuery.ExecuteNonQuery();
                stat = true;
                ConnG.Putus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return stat;
        }

    }
}