using Assessment.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment
{
    public class DataAccessLayer
    {
        public readonly IConfiguration _configuration;

        public DataAccessLayer(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        SqlConnection dbconn;
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        public DataTable GetProductType()
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetProductType", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }

        public DataTable GetOrderTypes()
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetOrderTypes", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }

        public DataTable GetLineNumberCount(int ordersID)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetLineNumberCount", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@OrdersID", ordersID);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }

        public DataTable GetOrderLines()
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetOrderLines", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }

        public DataTable GetOrderLineByID(int orderLineID)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_GetOrderLineById", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@OrderLineID", orderLineID);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }

        public int AddOrderLine(OrderLine orderLine)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_AddOrderLine", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@OrderLineNumber", orderLine.LineNumber);
            dbComm.Parameters.AddWithValue("@ProductCode", orderLine.ProductCode);
            dbComm.Parameters.AddWithValue("@ProductCostPrice", orderLine.ProductCostPrice);
            dbComm.Parameters.AddWithValue("@ProductSalesPrice", orderLine.ProductSalePrice);
            dbComm.Parameters.AddWithValue("@Quantity", orderLine.Quantity);
            dbComm.Parameters.AddWithValue("@ProductTypeID", orderLine.ProductTypeID);
            dbComm.Parameters.AddWithValue("@OrdersID", orderLine.OrdersID);

            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        public int UpdateOrderLine(OrderLine line)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_UpdateOrderLine", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@OrderLineID", line.OrderLineID);
            dbComm.Parameters.AddWithValue("@ProductCode", line.ProductCode);
            dbComm.Parameters.AddWithValue("@ProductCostPrice", line.ProductCostPrice);
            dbComm.Parameters.AddWithValue("@ProductSalesPrice", line.ProductSalePrice);
            dbComm.Parameters.AddWithValue("@Quantity", line.Quantity);
            dbComm.Parameters.AddWithValue("@ProductTypeID", line.ProductTypeID);
           


            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }
        public int DeleteOrderLine(OrderLine line)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteOrderLine", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@OrderLineID",line.OrderLineID);
            
            int x = dbComm.ExecuteNonQuery();
            dbconn.Close();

            return x;
        }

        #region Searches

        public DataTable SearchOrdersBetweenDates(DateTime minValue,DateTime maxValue)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_SearchOrderBetweenDates", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@MinDate", minValue);
            dbComm.Parameters.AddWithValue("@MaxDate", maxValue);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }
        public DataTable SearchOrdersByType(OrderType order)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_SearchOrderByType", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@OrderTypeID", order.OrderTypeID);
           

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }

        public DataTable SearchOrderLineByProductCode(SearchOrderLineVM search)
        {
            string connString = _configuration.GetConnectionString("connString");
            dbconn = new SqlConnection(connString);

            try
            {
                dbconn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_SearchProductCode", dbconn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ProductCode", search.ProductCode);


            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dbconn.Close();
            return dt;
        }
        #endregion
    }
}
