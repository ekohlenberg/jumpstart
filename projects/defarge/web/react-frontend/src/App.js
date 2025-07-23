import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'


// metric status (home page)
import HeaderComponent from './components/defarge-header';



  import CategoryListComponent from './components/category-list';
  import CategoryCreateComponent from './components/category-create';
  
  import UomListComponent from './components/uom-list';
  import UomCreateComponent from './components/uom-create';
  
  import ResourceTypeListComponent from './components/resource_type-list';
  import ResourceTypeCreateComponent from './components/resource_type-create';
  
  import OrgListComponent from './components/org-list';
  import OrgCreateComponent from './components/org-create';
  
  import UserListComponent from './components/user-list';
  import UserCreateComponent from './components/user-create';
  
  import ScriptListComponent from './components/script-list';
  import ScriptCreateComponent from './components/script-create';
  
  import OperationListComponent from './components/operation-list';
  import OperationCreateComponent from './components/operation-create';
  
  import OpRoleListComponent from './components/op_role-list';
  import OpRoleCreateComponent from './components/op_role-create';
  
  import ScheduleListComponent from './components/schedule-list';
  import ScheduleCreateComponent from './components/schedule-create';
  
  import WorkflowListComponent from './components/workflow-list';
  import WorkflowCreateComponent from './components/workflow-create';
  
  import ServerListComponent from './components/server-list';
  import ServerCreateComponent from './components/server-create';
  
  import MetricListComponent from './components/metric-list';
  import MetricCreateComponent from './components/metric-create';
  
  import ResourceListComponent from './components/resource-list';
  import ResourceCreateComponent from './components/resource-create';
  
  import UserOrgListComponent from './components/user_org-list';
  import UserOrgCreateComponent from './components/user_org-create';
  
  import UserPasswordListComponent from './components/user_password-list';
  import UserPasswordCreateComponent from './components/user_password-create';
  
  import EventServiceListComponent from './components/event_service-list';
  import EventServiceCreateComponent from './components/event_service-create';
  
  import ProcessListComponent from './components/process-list';
  import ProcessCreateComponent from './components/process-create';
  
  import OpRoleMapListComponent from './components/op_role_map-list';
  import OpRoleMapCreateComponent from './components/op_role_map-create';
  
  import OpRoleMemberListComponent from './components/op_role_member-list';
  import OpRoleMemberCreateComponent from './components/op_role_member-create';
  
  import ScheduleWorkflowListComponent from './components/schedule_workflow-list';
  import ScheduleWorkflowCreateComponent from './components/schedule_workflow-create';
  
  import MetricEventListComponent from './components/metric_event-list';
  import MetricEventCreateComponent from './components/metric_event-create';
  
  import AlertRuleListComponent from './components/alert_rule-list';
  import AlertRuleCreateComponent from './components/alert_rule-create';
  
  import MetricResourceMapListComponent from './components/metric_resource_map-list';
  import MetricResourceMapCreateComponent from './components/metric_resource_map-create';
  
  import ExecutionListComponent from './components/execution-list';
  import ExecutionCreateComponent from './components/execution-create';
  
  import WorkflowProcessListComponent from './components/workflow_process-list';
  import WorkflowProcessCreateComponent from './components/workflow_process-create';
  
  import AlertListComponent from './components/alert-list';
  import AlertCreateComponent from './components/alert-create';
  
// footer
import FooterComponent from './components/defarge-footer';

function App() {
  return (
    <div>
        <Router>
              <HeaderComponent />
                <div className="container">
                    <Routes> 
                         <Route path= '/' element = { < OrgListComponent /> } />
                           

                            <Route path='/category' element = { < CategoryListComponent /> } />
                            <Route path='/add-category/:id' element = { < CategoryCreateComponent /> } />
                            
                            <Route path='/uom' element = { < UomListComponent /> } />
                            <Route path='/add-uom/:id' element = { < UomCreateComponent /> } />
                            
                            <Route path='/resourcetype' element = { < ResourceTypeListComponent /> } />
                            <Route path='/add-resourcetype/:id' element = { < ResourceTypeCreateComponent /> } />
                            
                            <Route path='/org' element = { < OrgListComponent /> } />
                            <Route path='/add-org/:id' element = { < OrgCreateComponent /> } />
                            
                            <Route path='/user' element = { < UserListComponent /> } />
                            <Route path='/add-user/:id' element = { < UserCreateComponent /> } />
                            
                            <Route path='/script' element = { < ScriptListComponent /> } />
                            <Route path='/add-script/:id' element = { < ScriptCreateComponent /> } />
                            
                            <Route path='/operation' element = { < OperationListComponent /> } />
                            <Route path='/add-operation/:id' element = { < OperationCreateComponent /> } />
                            
                            <Route path='/oprole' element = { < OpRoleListComponent /> } />
                            <Route path='/add-oprole/:id' element = { < OpRoleCreateComponent /> } />
                            
                            <Route path='/schedule' element = { < ScheduleListComponent /> } />
                            <Route path='/add-schedule/:id' element = { < ScheduleCreateComponent /> } />
                            
                            <Route path='/workflow' element = { < WorkflowListComponent /> } />
                            <Route path='/add-workflow/:id' element = { < WorkflowCreateComponent /> } />
                            
                            <Route path='/server' element = { < ServerListComponent /> } />
                            <Route path='/add-server/:id' element = { < ServerCreateComponent /> } />
                            
                            <Route path='/metric' element = { < MetricListComponent /> } />
                            <Route path='/add-metric/:id' element = { < MetricCreateComponent /> } />
                            
                            <Route path='/resource' element = { < ResourceListComponent /> } />
                            <Route path='/add-resource/:id' element = { < ResourceCreateComponent /> } />
                            
                            <Route path='/userorg' element = { < UserOrgListComponent /> } />
                            <Route path='/add-userorg/:id' element = { < UserOrgCreateComponent /> } />
                            
                            <Route path='/userpassword' element = { < UserPasswordListComponent /> } />
                            <Route path='/add-userpassword/:id' element = { < UserPasswordCreateComponent /> } />
                            
                            <Route path='/eventservice' element = { < EventServiceListComponent /> } />
                            <Route path='/add-eventservice/:id' element = { < EventServiceCreateComponent /> } />
                            
                            <Route path='/process' element = { < ProcessListComponent /> } />
                            <Route path='/add-process/:id' element = { < ProcessCreateComponent /> } />
                            
                            <Route path='/oprolemap' element = { < OpRoleMapListComponent /> } />
                            <Route path='/add-oprolemap/:id' element = { < OpRoleMapCreateComponent /> } />
                            
                            <Route path='/oprolemember' element = { < OpRoleMemberListComponent /> } />
                            <Route path='/add-oprolemember/:id' element = { < OpRoleMemberCreateComponent /> } />
                            
                            <Route path='/scheduleworkflow' element = { < ScheduleWorkflowListComponent /> } />
                            <Route path='/add-scheduleworkflow/:id' element = { < ScheduleWorkflowCreateComponent /> } />
                            
                            <Route path='/metricevent' element = { < MetricEventListComponent /> } />
                            <Route path='/add-metricevent/:id' element = { < MetricEventCreateComponent /> } />
                            
                            <Route path='/alertrule' element = { < AlertRuleListComponent /> } />
                            <Route path='/add-alertrule/:id' element = { < AlertRuleCreateComponent /> } />
                            
                            <Route path='/metricresourcemap' element = { < MetricResourceMapListComponent /> } />
                            <Route path='/add-metricresourcemap/:id' element = { < MetricResourceMapCreateComponent /> } />
                            
                            <Route path='/execution' element = { < ExecutionListComponent /> } />
                            <Route path='/add-execution/:id' element = { < ExecutionCreateComponent /> } />
                            
                            <Route path='/workflowprocess' element = { < WorkflowProcessListComponent /> } />
                            <Route path='/add-workflowprocess/:id' element = { < WorkflowProcessCreateComponent /> } />
                            
                            <Route path='/alert' element = { < AlertListComponent /> } />
                            <Route path='/add-alert/:id' element = { < AlertCreateComponent /> } />
                            
                    </Routes>
                </div>
              <FooterComponent />
        </Router>
    </div>
    
  );
}

export default App;
