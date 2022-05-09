using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DataLayer;
using WebApiEF.Models;

namespace WebApiEF.Entity
{
    public class Service: IService
    {
        private readonly MyDBContext _dBContext;

        public Service(MyDBContext dBContext)
        {
            this._dBContext = dBContext;
        }

        public async Task<StateResponse<UserModel>> CreateAsync(UserModel user)
        {
            StateResponse<UserModel> _state = new StateResponse<UserModel>();
            try
            {
                var res = await _dBContext.UserModels.FirstOrDefaultAsync(p => p.Id == user.Id && p.FirstName == user.FirstName);
                if (res is null)
                {
                    _state.Code = (int)StatusResponse.Not_Found;
                    _state.Message = nameof(StatusResponse.Not_Found);
                    _state.Data = res;
                }
                if (res is not null)
                {
                    await _dBContext.UserModels.AddAsync(res);
                    _state.Code = (int)StatusResponse.Succes;
                    _state.Message = nameof(StatusResponse.Succes);
                    _state.Data = user;
                    await _dBContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                _state.Code = (int)StatusResponse.Error;
                _state.Message = nameof(StatusResponse.Error);
                _state.Data = null;
            }
            return _state;
        }

        public async Task<StateResponse<bool>> DeleteAsync(int id)
        {
            StateResponse<bool> _state = new StateResponse<bool>();
            try
            {
                var res = await _dBContext.UserModels.FirstOrDefaultAsync(p => p.Id == id);
                if (res is null)
                {
                    _state.Code = (int)StatusResponse.Not_Found;
                    _state.Message = nameof(StatusResponse.Not_Found);
                    _state.Data = false;
                }
                if (res is not null)
                {
                    _dBContext.UserModels.Remove(res);
                    _state.Code = (int)StatusResponse.Succes;
                    _state.Message = nameof(StatusResponse.Succes);
                    _state.Data = true;
                    await _dBContext.SaveChangesAsync();

                }

            }
            catch
            {
                _state.Code = (int)StatusResponse.Error;
                _state.Message = nameof(StatusResponse.Error);
                _state.Data = false;
            }
            return _state; 
        }

        public async Task<StateResponse<IEnumerable<UserModel>>> GetAllAsync()
        {
            StateResponse<IEnumerable<UserModel>> _state = new StateResponse<IEnumerable<UserModel>>();
            try
            {
                var res = await _dBContext.UserModels.ToListAsync();
                if (res is null)
                {
                    _state.Code = (int)StatusResponse.Not_Found;
                    _state.Message = nameof(StatusResponse.Not_Found);
                    _state.Data = null;
                }
                if (res is not null)
                {
                    _state.Code = (int)StatusResponse.Succes;
                    _state.Message = nameof(StatusResponse.Succes);
                    _state.Data = res;
                }
            }
            catch
            {
                _state.Code = (int)StatusResponse.Error;
                _state.Message = nameof(StatusResponse.Error);
                _state.Data = null;
            }
            return _state;
        }

        public async Task<StateResponse<UserModel>> GetAsync(int id)
        {
            StateResponse<UserModel> _state = new StateResponse<UserModel>();
            try
            {
                var user = await _dBContext.UserModels.FirstOrDefaultAsync(p => p.Id == id);
                if (user is null)
                {
                    _state.Code = (int)StatusResponse.Not_Found;
                    _state.Message = nameof(StatusResponse.Not_Found);
                    _state.Data = null;
                }
                if (user is not null)
                {
                    _state.Code = (int)StatusResponse.Succes;
                    _state.Message = nameof(StatusResponse.Succes);
                    _state.Data = user;
                    await _dBContext.SaveChangesAsync();
                }
            }
            catch
            {
                _state.Code = (int)StatusResponse.Error;
                _state.Message = nameof(StatusResponse.Error);
                _state.Data = null;
            }
            return _state;
        }

        public async Task<StateResponse<UserModel>> UpdateAsync(int id, UserModel user)
        {
            StateResponse<UserModel> _state = new StateResponse<UserModel>();
            try
            {
                var rersult = await _dBContext.UserModels.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (rersult is null)
                {
                    _state.Code = (int)StatusResponse.Not_Found;
                    _state.Message = nameof(StatusResponse.Not_Found);
                    _state.Data = null;
                }
                if (rersult is not null)
                {
                    rersult.FirstName = user.FirstName;
                    rersult.LastName = user.LastName;
                    rersult.Email = user.Email;
                    rersult.PhoneNumber = user.PhoneNumber;
                    _state.Code = (int)StatusResponse.Succes;
                    _state.Message = nameof(StatusResponse.Succes);
                    _state.Data = rersult;
                    await _dBContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                _state.Code = (int)StatusResponse.Error;
                _state.Message = nameof(StatusResponse.Error);
                _state.Data = null;
            }
             return _state;
        }
    }
}
