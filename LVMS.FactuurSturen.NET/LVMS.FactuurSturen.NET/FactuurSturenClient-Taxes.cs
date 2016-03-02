﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LVMS.FactuurSturen.Model;
using PortableRest;

namespace LVMS.FactuurSturen
{
    public partial class FactuurSturenClient
    {
        List<Taxes> _cachedTaxess;

        public async Task<Taxes[]> GetTaxes(bool? allowCache = true)
        {
            if (!allowCache.HasValue)
                allowCache = _allowResponseCaching;
            if ((bool)allowCache && _cachedTaxess != null)
                return _cachedTaxess.ToArray();

            var request = new RestRequest("taxes", HttpMethod.Get, ContentTypes.Json);

            var result = await _httpClient.ExecuteWithPolicyAsync<Taxes[]>(this, request);

            if ((bool)allowCache || _cachedTaxess != null)
                _cachedTaxess = new List<Taxes>(result);
            return result;
        }

        public async Task<Taxes> GetTaxType(TaxRates taxRate, bool? allowCache = true)
        {
            var taxes = await GetTaxes(allowCache);
            return taxes.FirstOrDefault(t => t.Type == taxRate);
        }
    }
}
