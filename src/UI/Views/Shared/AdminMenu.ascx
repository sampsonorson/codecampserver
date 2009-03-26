﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="CodeCampServer.UI.Controllers"%>

  <div class="h100">
  <h1>Administration</h1>  
  <ul>
          <li><a href="<%=Url.Action<AdminController>(c=>c.Edit(null)) %>"> Edit Admin Record</a></li>
        <li><a href="<%=Url.Action<ConferenceController>(c=>c.Edit(null)) %>"> Edit Conference</a></li>
        <li><a href="<%=Url.Action<TrackController>(c=>c.Index(null) )%>"> Edit Tracks</a></li>
        <li><a href="<%=Url.Action<TimeSlotController>(c=>c.Index(null)) %>"> Edit Timeslot</a></li>
        <li><a href="<%=Url.Action<SpeakerController>(c=>c.List(null)) %>"> Edit Speakers</a></li>
        <li><a href="<%=Url.Action<SessionController>(c=>c.List(null)) %>"> Edit Sessions</a></li>        
  </ul>
  </div>
