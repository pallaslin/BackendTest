
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Swashbuckle.AspNetCore.Filters;
using System.Data;
using System.Security.Cryptography;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly string connection = "Server=(localdb)\\mssqllocaldb;Database=BackendExamHub;Trusted_Connection=True;MultipleActiveResultSets=true;";
        public UserController() 
        {
        }

        /// <summary>
        /// 取得使用者列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserListViewModel>), 200)]
        [ProducesErrorResponseType(typeof(string))]
        public async Task<ActionResult<List<UserListViewModel>>> GetUsers()
        {
            try
            {
                List<UserListViewModel> result = new();
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string query = "SELECT ACPD_SID,ACPD_Cname,ACPD_Ename,ACPD_Status FROM MyOffice_ACPD;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserListViewModel _user = new()
                            {
                                Sid = reader["ACPD_SID"].ToString(),
                                CName = reader["ACPD_Cname"].ToString(),
                                EName = reader["ACPD_Ename"].ToString(),
                                Status = (byte)reader["ACPD_Status"]
                            };
                            result.Add(_user);
                        }
                    }
                    conn.Dispose();
                    conn.Close();
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesErrorResponseType(typeof(string))]
        [SwaggerRequestExample(typeof(UserViewModel), typeof(CreateUserRequestExample))]
        public async Task<ActionResult<string>> CreateUser([FromBody] UserViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException();
                }

                var _sid = string.Empty;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("NEWSID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TableName", "MyOffice_ACPD");
                        SqlParameter outputParam = new SqlParameter("@ReturnSID", SqlDbType.NVarChar, 20)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        await cmd.ExecuteNonQueryAsync();
                        _sid = outputParam.Value.ToString();
                    }

                    string query = "INSERT INTO MyOffice_ACPD (ACPD_SID, ACPD_Cname, ACPD_Ename, ACPD_Email, ACPD_Sname, ACPD_LoginID, ACPD_LoginPWD, ACPD_Status, ACPD_Stop, ACPD_NowDateTime, ACPD_NowID) " +
                        "VALUES (@sid, @CName, @EName, @EMail, @SName, @Account, @AccountPwd, 0, 0, GETDATE(), @sid)";
                    using (SqlCommand insert = new SqlCommand(query, conn))
                    {
                        insert.Parameters.AddWithValue("@sid", _sid);
                        insert.Parameters.AddWithValue("@CName", user.CName);
                        insert.Parameters.AddWithValue("@EName", user.EName);
                        insert.Parameters.AddWithValue("@EMail", user.EMail);
                        insert.Parameters.AddWithValue("@SName", user.SName);
                        insert.Parameters.AddWithValue("@Account", user.Account);
                        insert.Parameters.AddWithValue("@AccountPwd", user.AccountPwd);
                        await insert.ExecuteNonQueryAsync(); 
                    }
                    conn.Dispose();
                    conn.Close();
                }
                return _sid;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 修改使用者
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesErrorResponseType(typeof(string))]
        [SwaggerRequestExample(typeof(ModifyUserViewModel), typeof(UpdateUserRequestExample))]
        public async Task<ActionResult> UpdateUser( [FromBody] ModifyUserViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException();
                }
                if (string.IsNullOrEmpty(user.Sid))
                {
                    throw new Exception("No User Id");
                }

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "UPDATE MyOffice_ACPD SET ACPD_Cname = @CName, ACPD_Ename = @EName, ACPD_Sname = @SName, ACPD_Email = @EMail, ACPD_Status = @Status, ACPD_Stop = @IsStop, " +
                        "ACPD_StopMemo = @StopMemo, ACPD_LoginID = @Account, ACPD_LoginPWD = @AccountPwd, ACPD_Memo = @Memo, ACPD_UPDDateTime = GETDATE(), ACPD_UPDID = @sid " +
                        "WHERE ACPD_SID = @sid";
                    using (SqlCommand modify = new SqlCommand(query, conn))
                    {
                        modify.Parameters.AddWithValue("@sid", user.Sid);
                        modify.Parameters.AddWithValue("@CName", user.CName);
                        modify.Parameters.AddWithValue("@EName", user.EName);
                        modify.Parameters.AddWithValue("@EMail", user.EMail);
                        modify.Parameters.AddWithValue("@SName", user.SName);
                        modify.Parameters.AddWithValue("@Status", user.Status);
                        modify.Parameters.AddWithValue("@IsStop", user.IsStop);
                        modify.Parameters.AddWithValue("@StopMemo", user.StopMemo ?? (object)DBNull.Value);
                        modify.Parameters.AddWithValue("@Account", user.Account);
                        modify.Parameters.AddWithValue("@AccountPwd", user.AccountPwd);
                        modify.Parameters.AddWithValue("@Memo", user.Memo ?? (object)DBNull.Value);
                        await modify.ExecuteNonQueryAsync();
                    }
                    conn.Dispose();
                    conn.Close();
                }

                return NoContent();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="stopMemo"></param>
        /// <returns></returns>
        [HttpDelete("sid")]
        [ProducesResponseType(204)]
        [ProducesErrorResponseType(typeof(string))]
        public async Task<ActionResult> DeleteUser([FromQuery] string sid, [FromBody] string stopMemo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException();
                }
                if (string.IsNullOrEmpty(sid))
                {
                    throw new Exception("No User Id");
                }
                if (string.IsNullOrEmpty(stopMemo))
                {
                    throw new Exception("StopMemo must has reason.");
                }

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string query = "UPDATE MyOffice_ACPD SET ACPD_Stop = 1, ACPD_StopMemo = @StopMemo, ACPD_UPDDateTime = GETDATE(), ACPD_UPDID = @sid " +
                        "WHERE ACPD_SID = @sid";
                    using (SqlCommand modify = new SqlCommand(query, conn))
                    {
                        modify.Parameters.AddWithValue("@sid", sid);
                        modify.Parameters.AddWithValue("@StopMemo", stopMemo);
                        await modify.ExecuteNonQueryAsync();
                    }
                    conn.Dispose();
                    conn.Close();
                }

                return NoContent();
            }
            catch
            {
                throw;
            }
        }

    }
}
