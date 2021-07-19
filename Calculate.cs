using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_20210716
{
    class Calculate
    {
        public string GetCalResult (DateTime userStartDate, DateTime userEndDate,string carType, string displacement, decimal baseTax)
        {
            string result = string.Empty;
            decimal totalResult = 0;
            int startYear = userStartDate.Year ; 
            int endYear = userEndDate.Year;

            for (int execYear = startYear; execYear <= endYear; execYear++)
            {
                DateTime startDate;
                DateTime endDate;
                if (new DateTime(execYear, 1, 1) <= userStartDate)
                {
                    startDate = userStartDate;
                    if (new DateTime(execYear, 12, 31) > userEndDate)
                    {
                        endDate = userEndDate;
                        int countingPerior = (endDate - startDate).Days + 1;
                        int daysInYear = new DateTime(execYear, 12, 31).DayOfYear;
                        result += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        result += $"計算天數: {countingPerior} {Environment.NewLine}";
                        result += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        result += $"用途: {carType} {Environment.NewLine}";
                        result += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        result += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                    else
                    {
                        endDate = new DateTime(execYear, 12, 31);
                        int countingPerior = (endDate - startDate).Days + 1;
                        int daysInYear = new DateTime(execYear, 12, 31).DayOfYear;
                        result += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        result += $"計算天數: {countingPerior} {Environment.NewLine}";
                        result += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        result += $"用途: {carType} {Environment.NewLine}";
                        result += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        result += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                }
                else
                {
                    startDate = new DateTime(execYear, 1, 1);
                    if (new DateTime(execYear, 12, 31) > userEndDate)
                    {
                        endDate = userEndDate;
                        int countingPerior = (endDate - startDate).Days + 1;
                        int daysInYear = new DateTime(execYear, 12, 31).DayOfYear;
                        result += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        result += $"計算天數: {countingPerior} {Environment.NewLine}";
                        result += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        result += $"用途: {carType} {Environment.NewLine}";
                        result += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        result += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                    else
                    {
                        endDate = new DateTime(execYear, 12, 31);
                        int countingPerior  = (endDate - startDate).Days + 1;
                        int daysInYear  = new DateTime(execYear, 12, 31).DayOfYear;
                        result += $"使用期間: {startDate.ToString("yyyy-MM-dd")} ~ {endDate.ToString("yyyy-MM-dd")} {Environment.NewLine}";
                        result += $"計算天數: {countingPerior} {Environment.NewLine}";
                        result += $"汽缸CC數: {displacement} {Environment.NewLine}";
                        result += $"用途: {carType} {Environment.NewLine}";
                        result += $"計算公式: {baseTax} * {countingPerior} / {daysInYear} = {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine}";
                        result += $"應納稅額: 共 {(Math.Floor(baseTax * countingPerior / daysInYear)).ToString("N0")} 元 {Environment.NewLine} {Environment.NewLine}";
                        totalResult += Math.Floor(baseTax * countingPerior / daysInYear);
                    }
                }
            }
            // 如起訖日為不同年度則顯示全部應繳稅額
            if (startYear != endYear)
            {
                result += $"全部應納稅額: 共 {totalResult.ToString("N0")} 元";
            }

            return result;
        }
    }
}
