using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DVDLibrary.DLL
{
    public class DVDRepository : IDVDRepository
    {

        public List<DVDInfo> GetAllDVDs()
        {
            List<DVDInfo> dvds = new List<DVDInfo>();
            
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllDVDs";
                cmd.CommandType = CommandType.StoredProcedure;
                //jhgfhfyt

                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        dvds.Add(PopulateFromDataReader(dr));                       
                    }
                    
                }
            }

            return dvds;
        }

        public DVDInfo LoadDVD(int dvdID)
        {
            List<DVDInfo> dvds = GetAllDVDs();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LatestBorrower";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@dvdID", dvdID);

                cn.Open();
                DVDInfo dvd = new DVDInfo()
                {
                    BorrowerInfo = new BorrowerInformation()
                };
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                         dvd = PopulateFromDataReaderBorrowerInfo(dr);
                    }

                }
                return dvd;
           }
            
        }

        public void CreateDVD(DVDInfo DVD)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CreateDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@Title", DVD.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", DVD.ReleaseDate);
                cmd.Parameters.AddWithValue("@MPAARating", DVD.MPAARating);
                cmd.Parameters.AddWithValue("@DirectorsName", DVD.DirectorsName);
                cmd.Parameters.AddWithValue("@Studio", DVD.Studio);
                cmd.Parameters.AddWithValue("@UserRating", DVD.UserRating);
                cmd.Parameters.AddWithValue("@UserNotes", DVD.UserNotes);
                cmd.Parameters.AddWithValue("@ActorsInMovie", DVD.ActorsInMovies);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveDVDInfo(int dvdID)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@dvdID", dvdID);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<DVDInfo> SearchDVD(string dvdQuery)
        {
            List<DVDInfo> dvds = new List<DVDInfo>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SearchDVDs";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", dvdQuery);
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return dvds;
        }

        public void AddBorrower(DVDInfo borrowerInfo)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "AddBorrower";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdID", borrowerInfo.dvdID);
                cmd.Parameters.AddWithValue("@BorrowerName", borrowerInfo.BorrowerInfo.Borrower);
                cmd.Parameters.AddWithValue("@DateBorrowed", borrowerInfo.BorrowerInfo.DateBorrowed);
                cmd.Connection = cn;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ReturnDVD(DVDInfo borrower)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "ReturnDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdID", borrower.dvdID);
                cmd.Parameters.AddWithValue("@BorrowerName", borrower.BorrowerInfo.Borrower);
                cmd.Parameters.AddWithValue("@DateReturned", borrower.BorrowerInfo.DateReturned);
                cmd.Connection = cn;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private DVDInfo PopulateFromDataReader(SqlDataReader dr)
        {
            DVDInfo dvd = new DVDInfo();

            dvd.dvdID = (int) dr["dvdID"];
            dvd.Title = dr["Title"].ToString();
            dvd.ReleaseDate = dr["ReleaseDate"].ToString();
            dvd.MPAARating = dr["MPAARating"].ToString();
            dvd.DirectorsName = dr["DirectorsName"].ToString();
            dvd.Studio = dr["Studio"].ToString();
            dvd.UserRating = dr["UserRating"].ToString();
            dvd.ActorsInMovies = dr["ActorsInMovie"].ToString();

            if (dr["UserNotes"] != DBNull.Value)
                dvd.UserNotes = dr["UserNotes"].ToString();

            return dvd;
        }

        private DVDInfo PopulateFromDataReaderBorrowerInfo(SqlDataReader dr)
        {
            DVDInfo dvd = new DVDInfo()
            {
                BorrowerInfo = new BorrowerInformation()
            };

            dvd.dvdID = (int)dr["dvdID"];
            dvd.Title = dr["Title"].ToString();
            dvd.ReleaseDate = dr["ReleaseDate"].ToString();
            dvd.MPAARating = dr["MPAARating"].ToString();
            dvd.DirectorsName = dr["DirectorsName"].ToString();
            dvd.Studio = dr["Studio"].ToString();
            dvd.UserRating = dr["UserRating"].ToString();
            dvd.ActorsInMovies = dr["ActorsInMovie"].ToString();

            if (dr["UserNotes"] != DBNull.Value)
                dvd.UserNotes = dr["UserNotes"].ToString();

            if (dr["DateReturned"] == DBNull.Value)
            {
                dvd.BorrowerInfo.dvdID = dvd.dvdID;

                if (dr["BorrowerName"] != DBNull.Value)
                    dvd.BorrowerInfo.Borrower = dr["BorrowerName"].ToString();

                if (dr["DateBorrowed"] != DBNull.Value)
                    dvd.BorrowerInfo.DateBorrowed = (DateTime)dr["DateBorrowed"];
            }

            return dvd;
        }              

    }
}    

