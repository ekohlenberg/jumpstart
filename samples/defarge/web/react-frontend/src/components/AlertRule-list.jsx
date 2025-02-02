import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import AlertRuleService from '../services/alert_rule-service';

class AlertRuleListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                alertrules: []
        }
        this.addAlertRule = this.addAlertRule.bind(this);
        this.editAlertRule = this.editAlertRule.bind(this);
        this.deleteAlertRule = this.deleteAlertRule.bind(this);
    }

    deleteAlertRule(id){
        AlertRuleService.deleteAlertRule(id).then( res => {
            this.setState({ alertrules: this.state.alertrules.filter(alertrule => alertrule.id !== id) });
        });
    }
    viewAlertRule(id){
        this.props.navigate(`/view-alertrule/${id}`);
    }
    editAlertRule(id){
        console.log("editing " + id)
        this.props.navigate(`/add-alertrule/${id}`);
    }

    componentDidMount(){
        AlertRuleService.getAlertRules().then((res) => {
            this.setState({ alertrules: res.data});
        });
    }

    addAlertRule(){
        this.props.navigate('/add-alertrule/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">AlertRule List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addAlertRule}> Add AlertRule</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Metric</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Condition</th>
                                    
                                    <th>Threshold</th>
                                    
                                    <th>Recipients</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.alertrules.map(
                                        alertrule => 
                                        <tr key = { alertrule.id }>

                                                <td> { alertrule.id } </td>  
                                                
                                                <td> { alertrule.metric_id } </td>  
                                                
                                                <td> { alertrule.name } </td>  
                                                
                                                <td> { alertrule.condition } </td>  
                                                
                                                <td> { alertrule.threshold } </td>  
                                                
                                                <td> { alertrule.recipients } </td>  
                                                
                                                <td> { alertrule.is_active } </td>  
                                                
                                                <td> { alertrule.created_by } </td>  
                                                
                                                <td> { alertrule.last_updated } </td>  
                                                
                                                <td> { alertrule.last_updated_by } </td>  
                                                
                                                <td> { alertrule.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editAlertRule(alertrule.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteAlertRule(alertrule.id)} className="btn btn-danger">Delete </button>
                                                
                                             </td>
                                        </tr>
                                    )
                                }
                            </tbody>
                        </table>

                 </div>

            </div>
        )
    }
}

export default withNavigation(AlertRuleListComponent);