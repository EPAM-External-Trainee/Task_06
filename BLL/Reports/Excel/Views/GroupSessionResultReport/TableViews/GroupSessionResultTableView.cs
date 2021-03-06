﻿using BLL.Reports.Excel.Views.GroupSessionResultReport.TableRowViews;
using BLL.Reports.Excel.Views.GroupSessionResultReport.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews
{
    /// <summary>Class describing the view of the group session result table</summary>
    public class GroupSessionResultTableView : IGroupSessionResultTableView
    {
        /// <summary>Default constructor</summary>
        public GroupSessionResultTableView()
        {
        }

        /// <summary>Creating an instance of <see cref="GroupSessionResultTableView"/> via table row views, session name and academic year</summary>
        /// <param name="tableRowViews">Table row views</param>
        /// <param name="sessionName">Session name</param>
        /// <param name="academicYear">Academic year</param>
        public GroupSessionResultTableView(IEnumerable<GroupSessionResultTableRowView> tableRowViews, string sessionName, string academicYear)
        {
            TableRowViews = tableRowViews;
            SessionName = sessionName;
            AcademicYear = academicYear;
        }

        /// <inheritdoc cref="IGroupSessionResultTableView.Headers"/>
        public string[] Headers { get; } = { "Group name", "Max assessment", "Min assessment", "Average assessment" };

        /// <inheritdoc cref="IGroupSessionResultTableView.TableRowViews"/>
        public IEnumerable<GroupSessionResultTableRowView> TableRowViews { get; set; }

        /// <inheritdoc cref="IGroupSessionResultTableView.SessionName"/>
        public string SessionName { get; set; }

        /// <inheritdoc cref="IGroupSessionResultTableView.AcademicYear"/>
        public string AcademicYear { get; set; }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj) => obj is GroupSessionResultTableView view && Headers.SequenceEqual(view.Headers) && TableRowViews.SequenceEqual(view.TableRowViews) && SessionName == view.SessionName && AcademicYear == view.AcademicYear;

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => HashCode.Combine(Headers, TableRowViews, SessionName, AcademicYear);
    }
}