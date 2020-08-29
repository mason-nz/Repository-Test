﻿/**
 @Name : layDate v1.1 日期控件
 */
!function (c) { var a = { path: "", skin: "default", format: "YYYY-MM-DD", min: "1900-01-01 00:00:00", max: "2099-12-31 23:59:59", isv: false, init: true, isInitCheck: true, voidDateRange: [], selectedPoint: [], isNeedConfirm: false, isShowHoliday: false, showHolidayRequestURL: "/api/common/GetHolidaysInfo?jsonpcallback=?" }; var f = {}, d = document, e = "createElement", g = "getElementById", i = "getElementsByTagName"; var b = ["laydate_box", "laydate_void", "laydate_click", "LayDateSkin", "skins/", "/laydate.css", "laydate_curClick"]; c.laydate = function (j) { j = j || {}; try { b.event = c.event ? c.event : laydate.caller.arguments[0] } catch (k) { } f.run(j); return laydate }; laydate.v = "1.1"; f.getPath = (function () { var k = document.scripts, j = k[k.length - 1].src; return a.path ? a.path : j.substring(0, j.lastIndexOf("/") + 1) }()); f.use = function (k, l) { var j = d[e]("link"); j.type = "text/css"; j.rel = "stylesheet"; j.href = f.getPath + k + b[5]; l && (j.id = l); d[i]("head")[0].appendChild(j); j = null }; f.trim = function (j) { j = j || ""; return j.replace(/^\s|\s$/g, "").replace(/\s+/g, " ") }; f.digit = function (j) { return j < 10 ? "0" + (j | 0) : j }; f.stopmp = function (j) { j = j || c.event; j.stopPropagation ? j.stopPropagation() : j.cancelBubble = true; return this }; f.each = function (k, m) { var l = 0, j = k.length; for (; l < j; l++) { if (m(l, k[l]) === false) { break } } }; f.hasClass = function (k, j) { k = k || {}; return new RegExp("\\b" + j + "\\b").test(k.className) }; f.addClass = function (k, j) { k = k || {}; f.hasClass(k, j) || (k.className += " " + j); k.className = f.trim(k.className); return this }; f.removeClass = function (l, j) { l = l || {}; if (f.hasClass(l, j)) { var k = new RegExp("\\b" + j + "\\b"); l.className = l.className.replace(k, "") } return this }; f.removeCssAttr = function (l, j) { var k = l.style; if (k.removeProperty) { k.removeProperty(j) } else { k.removeAttribute(j) } }; f.shde = function (k, j) { k.style.display = j ? "none" : "block" }; f.query = function (k) { if (k && k.nodeType === 1) { if (k.tagName.toLowerCase() !== "input") { throw new Error("选择器elem错误") } return k } var k = (f.trim(k)).split(" "), n = d[g](k[0].substr(1)), j; if (!n) { return } else { if (!k[1]) { return n } else { if (/^\./.test(k[1])) { var m, o = k[1].substr(1), l = new RegExp("\\b" + o + "\\b"); j = []; m = d.getElementsByClassName ? n.getElementsByClassName(o) : n[i]("*"); f.each(m, function (p, q) { l.test(q.className) && j.push(q) }); return j[0] ? j : "" } else { j = n[i](k[1]); return j[0] ? n[i](k[1]) : "" } } } }; f.on = function (k, l, j) { k.attachEvent ? k.attachEvent("on" + l, function () { j.call(k, c.even) }) : k.addEventListener(l, j, false); return f }; f.stopMosup = function (j, k) { if (j !== "mouseup") { f.on(k, "mouseup", function (l) { f.stopmp(l) }) } }; f.run = function (j) { var k = f.query, l, p, o = b.event, n; try { n = o.target || o.srcElement || {} } catch (m) { n = {} } l = j.elem ? k(j.elem) : n; b.elemv = /textarea|input/.test(l.tagName.toLocaleLowerCase()) ? "value" : "innerHTML"; if (("init" in j ? j.init : a.init) && (!l[b.elemv])) { l[b.elemv] = laydate.now(null, j.format || a.format) } if (o && n.tagName) { if (!l || l === f.elem) { return } f.stopMosup(o.type, l); f.stopmp(o); f.view(l, j); f.reshow() } else { p = j.event || "click"; f.each((l.length | 0) > 0 ? l : [l], function (q, r) { f.stopMosup(p, r); f.on(r, p, function (s) { f.stopmp(s); if (r !== f.elem) { f.view(r, j); f.reshow() } }) }) } h(j.skin || a.skin); f.RenderVoidDateRange(); f.RenderSelectedPoint() }; f.checkDate = function (l) { var j = f.options.format.replace(/YYYY|MM|DD|hh|mm|ss/g, "\\d+\\").replace(/\\$/g, ""); var k = new RegExp(j); if (!k.test(l)) { return false } return true }; f.RenderVoidDateRange = function () { if (f.options.voidDateRange && $.isArray(f.options.voidDateRange)) { var l = false; if (f.options.voidDateRange.length > 0) { for (var o = 0; o < f.options.voidDateRange.length; o++) { var k = f.options.voidDateRange[o].S; var r = f.options.voidDateRange[o].E; if (!(k && r && k.parseDate() <= r.parseDate())) { l = true; break } } if (l == false) { for (var n = 0; n < f.options.voidDateRange.length; n++) { var k = f.options.voidDateRange[n].S.parseDate(); var r = f.options.voidDateRange[n].E.parseDate(); while (k <= r) { var p = k.Format("yyyy"); var q = k.Format("M"); var m = k.Format("d"); $('div.laydate_box > table.laydate_table > tbody > tr > td[y="' + p + '"][m="' + q + '"][d="' + m + '"]').addClass("laydate_void"); k = k.addDate(1) } } } } } }; f.RenderSelectedPoint = function () { if (f.options.selectedPoint && $.isArray(f.options.selectedPoint)) { var l = false; if (f.options.selectedPoint.length > 0) { for (var p = 0; p < f.options.selectedPoint.length; p++) { var n = f.options.selectedPoint[p]; if (!(n && n.isDate())) { l = true; break } } if (l == false) { for (var o = 0; o < f.options.selectedPoint.length; o++) { var k = f.options.selectedPoint[o].parseDate(); var q = k.Format("yyyy"); var r = k.Format("M"); var m = k.Format("d"); $('div.laydate_box > table.laydate_table > tbody > tr > td[y="' + q + '"][m="' + r + '"][d="' + m + '"]').addClass("laydate_click") } } } } }; f.scroll = function (j) { j = j ? "scrollLeft" : "scrollTop"; return d.body[j] | d.documentElement[j] }; f.winarea = function (j) { return document.documentElement[j ? "clientWidth" : "clientHeight"] }; f.isleap = function (j) { return (j % 4 === 0 && j % 100 !== 0) || j % 400 === 0 }; f.checkVoid = function (j, m, k) { var l = []; j = j | 0; m = m | 0; k = k | 0; if (j < f.mins[0]) { l = ["y"] } else { if (j > f.maxs[0]) { l = ["y", 1] } else { if (j >= f.mins[0] && j <= f.maxs[0]) { if (j == f.mins[0]) { if (m < f.mins[1]) { l = ["m"] } else { if (m == f.mins[1]) { if (k < f.mins[2]) { l = ["d"] } } } } if (j == f.maxs[0]) { if (m > f.maxs[1]) { l = ["m", 1] } else { if (m == f.maxs[1]) { if (k > f.maxs[2]) { l = ["d", 1] } } } } } } } return l }; f.timeVoid = function (k, j) { if (f.ymd[1] + 1 == f.mins[1] && f.ymd[2] == f.mins[2]) { if (j === 0 && (k < f.mins[3])) { return 1 } else { if (j === 1 && k < f.mins[4]) { return 1 } else { if (j === 2 && k < f.mins[5]) { return 1 } } } } else { if (f.ymd[1] + 1 == f.maxs[1] && f.ymd[2] == f.maxs[2]) { if (j === 0 && k > f.maxs[3]) { return 1 } else { if (j === 1 && k > f.maxs[4]) { return 1 } else { if (j === 2 && k > f.maxs[5]) { return 1 } } } } } if (k > (j ? 59 : 23)) { return 1 } }; f.check = function () { var k = f.options.format.replace(/YYYY|MM|DD|hh|mm|ss/g, "\\d+\\").replace(/\\$/g, ""); var n = new RegExp(k), l = f.elem[b.elemv]; var j = l.match(/\d+/g) || [], m = f.checkVoid(j[0], j[1], j[2]); if (l.replace(/\s/g, "") !== "") { if (!n.test(l)) { f.elem[b.elemv] = ""; f.msg("日期不符合格式，请重新选择。"); return 1 } else { if (m[0]) { f.elem[b.elemv] = ""; f.msg("日期不在有效期内，请重新选择。"); return 1 } else { m.value = f.elem[b.elemv].match(n).join(); j = m.value.match(/\d+/g); if (j[1] < 1) { j[1] = 1; m.auto = 1 } else { if (j[1] > 12) { j[1] = 12; m.auto = 1 } else { if (j[1].length < 2) { m.auto = 1 } } } if (j[2] < 1) { j[2] = 1; m.auto = 1 } else { if (j[2] > f.months[(j[1] | 0) - 1]) { j[2] = 31; m.auto = 1 } else { if (j[2].length < 2) { m.auto = 1 } } } if (j.length > 3) { if (f.timeVoid(j[3], 0)) { m.auto = 1 } if (f.timeVoid(j[4], 1)) { m.auto = 1 } if (f.timeVoid(j[5], 2)) { m.auto = 1 } } if (m.auto) { f.creation([j[0], j[1] | 0, j[2] | 0], 1) } else { if (m.value !== f.elem[b.elemv]) { f.elem[b.elemv] = m.value } } } } } }; f.months = [31, null, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]; f.viewDate = function (o, p, n, m) { var k = f.query, l = {}, j = new Date(); o < (f.mins[0] | 0) && (o = (f.mins[0] | 0)); o > (f.maxs[0] | 0) && (o = (f.maxs[0] | 0)); j.setFullYear(o, p, n); l.ymd = [j.getFullYear(), j.getMonth(), j.getDate()]; f.months[1] = f.isleap(l.ymd[0]) ? 29 : 28; j.setFullYear(l.ymd[0], l.ymd[1], 1); l.FDay = j.getDay(); l.PDay = f.months[p === 0 ? 11 : p - 1] - l.FDay + 1; l.NDay = 1; f.each(b.tds, function (s, t) { var q = l.ymd[0], u = l.ymd[1] + 1, r; t.className = ""; if (s < l.FDay) { t.innerHTML = r = s + l.PDay; f.addClass(t, "laydate_nothis"); u === 1 && (q -= 1); u = u === 1 ? 12 : u - 1 } else { if (s >= l.FDay && s < l.FDay + f.months[l.ymd[1]]) { t.innerHTML = r = s - l.FDay + 1; if (s - l.FDay + 1 === l.ymd[2] && !m) { f.addClass(t, b[2]); l.thisDay = t } } else { t.innerHTML = r = l.NDay++; f.addClass(t, "laydate_nothis"); u === 12 && (q += 1); u = u === 12 ? 1 : u + 1 } } if (f.checkVoid(q, u, r)[0]) { f.addClass(t, b[1]) } f.options.festival && f.festival(t, u + "." + r); f.options.isShowHoliday && f.ShowHoliday(t, q, u, r); t.setAttribute("y", q); t.setAttribute("m", u); t.setAttribute("d", r); q = u = r = null }); f.valid = !f.hasClass(l.thisDay, b[1]); f.ymd = l.ymd; b.year.value = f.ymd[0] + "年"; b.month.value = f.digit(f.ymd[1] + 1) + "月"; f.each(b.mms, function (q, r) { var s = f.checkVoid(f.ymd[0], (r.getAttribute("m") | 0) + 1); if (s[0] === "y" || s[0] === "m") { f.addClass(r, b[1]) } else { f.removeClass(r, b[1]) } f.removeClass(r, b[2]); s = null }); f.addClass(b.mms[f.ymd[1]], b[2]); l.times = [f.inymd[f.elemIndexMap.hour] | 0 || 0, f.inymd[f.elemIndexMap.minute] | 0 || 0, f.inymd[f.elemIndexMap.second] | 0 || 0]; f.each(new Array(3), function (q) { f.hmsin[q].value = f.digit(f.timeVoid(l.times[q], q) ? f.mins[q + 3] | 0 : l.times[q] | 0) }); f[f.valid ? "removeClass" : "addClass"](b.ok, b[1]) }; f.festival = function (l, j) { var k; switch (j) { case "1.1": k = "元旦"; break; case "3.8": k = "妇女"; break; case "4.5": k = "清明"; break; case "5.1": k = "劳动"; break; case "6.1": k = "儿童"; break; case "9.10": k = "教师"; break; case "10.1": k = "国庆"; break } k && (l.innerHTML = k); k = null }; f.ShowHoliday = function (m, k, l, j) { if (f.options.isShowHoliday && f.options.isShowHoliday == true && a.showHolidayRequestURL && f.HolidaysData) { if (f.HolidaysData[k] && f.HolidaysData[k].length > 0) { $.each(f.HolidaysData[k], function (q, s) { var n = s.StartDate.parseDate(); var r = s.EndDate.parseDate(); var p = s.Name; var o = (k + "-" + l + "-" + j).parseDate(); if (o >= n && o <= r) { m.innerHTML = "假"; $(m).attr("h", m.innerHTML) } }) } } }; f.viewYears = function (j) { var k = f.query, l = ""; f.each(new Array(14), function (m) { if (m === 7) { l += "<li " + (parseInt(b.year.value) === j ? 'class="' + b[2] + '"' : "") + ' y="' + j + '">' + j + "年</li>" } else { l += '<li y="' + (j - 7 + m) + '">' + (j - 7 + m) + "年</li>" } }); k("#laydate_ys").innerHTML = l; f.each(k("#laydate_ys li"), function (m, n) { if (f.checkVoid(n.getAttribute("y"))[0] === "y") { f.addClass(n, b[1]) } else { f.on(n, "click", function (o) { f.stopmp(o).reshow(); f.viewDate(this.getAttribute("y") | 0, f.ymd[1], f.ymd[2], true) }) } }) }; f.getEachElementIndex = function (l) { var k = {}; var j = 0; l.replace(/YYYY|MM|DD|hh|mm|ss/g, function (n, m) { if (n === "YYYY") { k["year"] = j++ } else { if (n === "MM") { k["month"] = j++ } else { if (n === "DD") { k["day"] = j++ } else { if (n === "hh") { k["hour"] = j++ } else { if (n === "mm") { k["minute"] = j++ } else { if (n === "ss") { k["second"] = j++ } } } } } } return "" }); return k }; f.initDate = function (o) { var k = f.query, l = {}, j = new Date(); var m = f.elem[b.elemv].match(/\d+/g) || []; var n = f.getEachElementIndex(o); f.elemIndexMap = n; if (m.length < 3) { m = f.options.start.match(/\d+/g) || []; if (m.length < 3) { m = [j.getFullYear(), j.getMonth() + 1, j.getDate()] } } f.inymd = m; if (f.options.isShowHoliday && f.options.isShowHoliday == true && a.showHolidayRequestURL) { if (!f.HolidaysData) { $.ajaxSettings.async = false; $.getJSON(a.showHolidayRequestURL, function (p) { if (p && p.Result) { f.HolidaysData = p.Result } }); $.ajaxSettings.async = true } } f.viewDate(m[n.year], m[n.month] - 1, m[n.day]) }; f.iswrite = function () { var j = f.query, k = { time: j("#laydate_hms") }; f.shde(k.time, !f.options.istime); f.shde(b.oclear, !("isclear" in f.options ? f.options.isclear : 1)); f.shde(b.otoday, !("istoday" in f.options ? f.options.istoday : 1)); f.shde(b.ok, !("issure" in f.options ? f.options.issure : 0)) }; f.orien = function (k, m) { var l, j = f.elem.getBoundingClientRect(); k.style.left = j.left + (m ? 0 : f.scroll(1)) + "px"; if (j.bottom + k.offsetHeight / 1.5 <= f.winarea()) { l = j.bottom - 1 } else { l = j.top > k.offsetHeight / 1.5 ? j.top - k.offsetHeight + 1 : f.winarea() - k.offsetHeight } k.style.top = Math.max(l + (m ? 0 : f.scroll()), 1) + "px" }; f.follow = function (j) { if (f.options.fixed) { j.style.position = "fixed"; f.orien(j, 1) } else { j.style.position = "absolute"; f.orien(j) } }; f.viewtb = (function () { var o, j = [], m = ["日", "一", "二", "三", "四", "五", "六"]; var k = {}, l = d[e]("table"), n = d[e]("thead"); n.appendChild(d[e]("tr")); k.creath = function (p) { var q = d[e]("th"); q.innerHTML = m[p]; n[i]("tr")[0].appendChild(q); q = null }; f.each(new Array(6), function (p) { j.push([]); o = l.insertRow(0); f.each(new Array(7), function (q) { j[p][q] = 0; p === 0 && k.creath(q); o.insertCell(q) }) }); l.insertBefore(n, l.children[0]); l.id = l.className = "laydate_table"; o = j = null; return l.outerHTML.toLowerCase() }()); f.view = function (m, j) { var k = f.query, n, l = {}; j = j || m; f.elem = m; f.options = j; f.options.format || (f.options.format = a.format); f.options.start = f.options.start || ""; f.mm = l.mm = [f.options.min || a.min, f.options.max || a.max]; f.mins = l.mm[0].match(/\d+/g); f.maxs = l.mm[1].match(/\d+/g); if (!f.box) { n = d[e]("div"); n.id = b[0]; n.className = b[0]; n.style.cssText = "position: absolute;"; n.setAttribute("name", "laydate-v" + laydate.v); n.innerHTML = l.html = '<div class="laydate_top">' + '<div class="laydate_ym laydate_y" id="laydate_YY">' + '<a class="laydate_choose laydate_chprev laydate_tab"><cite></cite></a>' + '<input id="laydate_y" readonly><label></label>' + '<a class="laydate_choose laydate_chnext laydate_tab"><cite></cite></a>' + '<div class="laydate_yms">' + '<a class="laydate_tab laydate_chtop"><cite></cite></a>' + '<ul id="laydate_ys"></ul>' + '<a class="laydate_tab laydate_chdown"><cite></cite></a>' + "</div>" + "</div>" + '<div class="laydate_ym laydate_m" id="laydate_MM">' + '<a class="laydate_choose laydate_chprev laydate_tab"><cite></cite></a>' + '<input id="laydate_m" readonly><label></label>' + '<a class="laydate_choose laydate_chnext laydate_tab"><cite></cite></a>' + '<div class="laydate_yms" id="laydate_ms">' + function () { var o = ""; f.each(new Array(12), function (p) { o += '<span m="' + p + '">' + f.digit(p + 1) + "月</span>" }); return o }() + "</div>" + "</div>" + "</div>" + f.viewtb + '<div class="laydate_bottom">' + '<ul id="laydate_hms">' + '<li class="laydate_sj">时间</li>' + "<li><input readonly>:</li>" + "<li><input readonly>:</li>" + "<li><input readonly></li>" + "</ul>" + '<div class="laydate_time" id="laydate_time"></div>' + '<div class="laydate_btn">' + '<a id="laydate_clear">清空</a>' + '<a id="laydate_today">今天</a>' + '<a id="laydate_ok">确认</a>' + "</div>" + (a.isv ? '<a href="http://sentsin.com/layui/laydate/" class="laydate_v" target="_blank">laydate-v' + laydate.v + "</a>" : "") + "</div>"; d.body.appendChild(n); f.box = k("#" + b[0]); f.events(); n = null } else { f.shde(f.box) } f.follow(f.box); j.zIndex ? f.box.style.zIndex = j.zIndex : f.removeCssAttr(f.box, "z-index"); f.stopMosup("click", f.box); f.initDate(j.format); f.iswrite(); f.options.isInitCheck = ("isInitCheck" in f.options ? f.options.isInitCheck : true); if (f.options.isInitCheck) { f.check() } }; f.reshow = function () { f.each(f.query("#" + b[0] + " .laydate_show"), function (j, k) { f.removeClass(k, "laydate_show") }); return this }; f.close = function () { f.reshow(); f.shde(f.query("#" + b[0]), 1); f.elem = null }; f.parse = function (k, j, l) { k = k.concat(j); l = l || (f.options ? f.options.format : a.format); return l.replace(/YYYY|MM|DD|hh|mm|ss/g, function (n, m) { var o = -1; if (n === "YYYY") { o = 0 } else { if (n === "MM") { o = 1 } else { if (n === "DD") { o = 2 } else { if (n === "hh") { o = 3 } else { if (n === "mm") { o = 4 } else { if (n === "ss") { o = 5 } } } } } } return f.digit(k[o]) }) }; f.creation = function (o, m, l) { var k = f.query, n = f.hmsin; var j = f.parse(o, [n[0].value, n[1].value, n[2].value]); var p = {}; f.elem[b.elemv] = j; if (l && l != "") { p.HolidayName = l } if (!m) { f.close(); typeof f.options.choose === "function" && f.options.choose(j, p) } }; f.events = function () { var j = f.query, k = { box: "#" + b[0] }; f.addClass(d.body, "laydate_body"); b.tds = j("#laydate_table td"); b.mms = j("#laydate_ms span"); b.year = j("#laydate_y"); b.month = j("#laydate_m"); f.each(j(k.box + " .laydate_ym"), function (l, m) { f.on(m, "click", function (n) { f.stopmp(n).reshow(); f.addClass(this[i]("div")[0], "laydate_show"); if (!l) { k.YY = parseInt(b.year.value); f.viewYears(k.YY) } }) }); f.on(j(k.box), "click", function (l) { if (l && l.target && $(l.target).parent("div.laydte_hsmtex:visible").size() > 0) { f.reshow() } if (k.box != "#laydate_box") { f.reshow() } }); k.tabYear = function (l) { if (l === 0) { f.ymd[0]-- } else { if (l === 1) { f.ymd[0]++ } else { if (l === 2) { k.YY -= 14 } else { k.YY += 14 } } } if (l < 2) { f.viewDate(f.ymd[0], f.ymd[1], f.ymd[2], true); f.reshow() } else { f.viewYears(k.YY) } f.RenderVoidDateRange(); f.RenderSelectedPoint() }; f.each(j("#laydate_YY .laydate_tab"), function (l, m) { f.on(m, "click", function (n) { f.stopmp(n); k.tabYear(l) }) }); k.tabMonth = function (l) { if (l) { f.ymd[1]++; if (f.ymd[1] === 12) { f.ymd[0]++; f.ymd[1] = 0 } } else { f.ymd[1]--; if (f.ymd[1] === -1) { f.ymd[0]--; f.ymd[1] = 11 } } f.viewDate(f.ymd[0], f.ymd[1], f.ymd[2], true); f.RenderVoidDateRange(); f.RenderSelectedPoint() }; f.each(j("#laydate_MM .laydate_tab"), function (l, m) { f.on(m, "click", function (n) { f.stopmp(n).reshow(); k.tabMonth(l) }) }); f.each(j("#laydate_ms span"), function (l, m) { f.on(m, "click", function (n) { f.stopmp(n).reshow(); if (!f.hasClass(this, b[1])) { f.viewDate(f.ymd[0], this.getAttribute("m") | 0, f.ymd[2], true) } }) }); f.each(j("#laydate_table td"), function (l, m) { f.on(m, "click", function (n) { $("div.laydate_box > table.laydate_table > tbody > tr > td[y][m][d]").removeClass(b[6]); if (!f.hasClass(this, b[6])) { f.stopmp(n); f.addClass(this, b[6]) } if (!f.hasClass(this, b[1])) { f.stopmp(n); f.ymd = [this.getAttribute("y") | 0, (this.getAttribute("m") | 0) > 0 ? (this.getAttribute("m") | 0) - 1 : 0, this.getAttribute("d") | 0]; f.creation([this.getAttribute("y") | 0, this.getAttribute("m") | 0, this.getAttribute("d") | 0], f.options.isNeedConfirm, $(m).attr("h")) } }) }); b.oclear = j("#laydate_clear"); f.on(b.oclear, "click", function () { f.elem[b.elemv] = ""; f.close() }); b.otoday = j("#laydate_today"); f.on(b.otoday, "click", function () { var l = new Date(); f.elem[b.elemv] = laydate.now(0, f.options.format); f.viewDate(l.getFullYear(), l.getMonth(), l.getDate()); $('div.laydate_box > table.laydate_table > tbody > tr > td[y="' + l.getFullYear() + '"][m="' + (l.getMonth() + 1) + '"][d="' + l.getDate() + '"]').addClass(b[6]); f.reshow(); f.RenderVoidDateRange(); f.RenderSelectedPoint(); f.creation([l.getFullYear(), l.getMonth() + 1, l.getDate()], f.options.isNeedConfirm) }); b.ok = j("#laydate_ok"); f.on(b.ok, "click", function () { if (f.valid) { var l = $("div.laydate_box > table.laydate_table > tbody > tr > td.laydate_curClick[y][m][d]"); if (l.size() == 1) { f.creation([l.attr("y"), l.attr("m"), l.attr("d")], null, l.attr("h")) } else { f.msg("请选择一个日期！") } } }); k.times = j("#laydate_time"); f.hmsin = k.hmsin = j("#laydate_hms input"); k.hmss = ["小时", "分钟", "秒数"]; k.hmsarr = []; f.msg = function (l, n) { var m = '<div class="laydte_hsmtex">' + (n || "提示") + "<span>×</span></div>"; if (typeof l === "string") { m += "<p>" + l + "</p>"; f.shde(j("#" + b[0])); f.removeClass(k.times, "laydate_time1").addClass(k.times, "laydate_msg") } else { if (!k.hmsarr[l]) { m += '<div id="laydate_hmsno" class="laydate_hmsno">'; f.each(new Array(l === 0 ? 24 : 60), function (o) { m += "<span>" + o + "</span>" }); m += "</div>"; k.hmsarr[l] = m } else { m = k.hmsarr[l] } f.removeClass(k.times, "laydate_msg"); f[l === 0 ? "removeClass" : "addClass"](k.times, "laydate_time1") } f.addClass(k.times, "laydate_show"); k.times.innerHTML = m }; k.hmson = function (m, n) { var o = j("#laydate_hmsno span"), q = f.valid ? null : 1; var p = $(m).parent().next().find(":input:first"); var l = n + 1; f.each(o, function (r, s) { if (q) { f.addClass(s, b[1]) } else { if (f.timeVoid(r, n)) { f.addClass(s, b[1]) } else { f.on(s, "click", function (t) { if (!f.hasClass(this, b[1])) { m.value = f.digit(this.innerHTML | 0); if (p && p.size() > 0) { p.click() } if (l >= 3) { f.stopmp(m).reshow() } } }) } } }); f.addClass(o[m.value | 0], "laydate_click") }; f.each(k.hmsin, function (l, m) { f.on(m, "click", function (n) { f.stopmp(n).reshow(); f.msg(l, k.hmss[l]); k.hmson(this, l) }) }); f.on(d, "mouseup", function () { var l = j("#" + b[0]); if (l && l.style.display !== "none") { if (f.options.isInitCheck) { f.check() || f.close() } else { f.close() } } }).on(d, "keydown", function (m) { m = m || c.event; var l = m.keyCode; if (l === 13 && f.elem) { f.creation([f.ymd[0], f.ymd[1] + 1, f.ymd[2]]) } }) }; f.init = (function () { f.use("need"); f.use(b[4] + a.skin, b[3]); f.skinLink = f.query("#" + b[3]) }()); laydate.reset = function () { (f.box && f.elem) && f.follow(f.box) }; laydate.now = function (k, l) { var j = new Date((k | 0) ? function (m) { return m < 86400000 ? (+new Date + m * 86400000) : m }(parseInt(k)) : +new Date); return f.parse([j.getFullYear(), j.getMonth() + 1, j.getDate()], [j.getHours(), j.getMinutes(), j.getSeconds()], l) }; laydate.skin = h; function h(j) { f.skinLink.href = f.getPath + b[4] + j + b[5] } }(window);