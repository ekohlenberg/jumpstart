import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ActionGroupMapService from '../services/action_group_map-service';

class ActionGroupMapListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                actiongroupmaps: []
        }
        this.addActionGroupMap = this.addActionGroupMap.bind(this);
        this.editActionGroupMap = this.editActionGroupMap.bind(this);
        this.deleteActionGroupMap = this.deleteActionGroupMap.bind(this);
    }

    deleteActionGroupMap(id){
        ActionGroupMapService.deleteActionGroupMap(id).then( res => {
            this.setState({ actiongroupmaps: this.state.actiongroupmaps.filter(actiongroupmap => actiongroupmap.id !== id) });
        });
    }
    viewActionGroupMap(id){
        this.props.navigate(`/view-actiongroupmap/${id}`);
    }
    editActionGroupMap(id){
        console.log("editing " + id)
        this.props.navigate(`/add-actiongroupmap/${id}`);
    }

    componentDidMount(){
        ActionGroupMapService.getActionGroupMaps().then((res) => {
            this.setState({ actiongroupmaps: res.data});
        });
    }

    addActionGroupMap(){
        this.props.navigate('/add-actiongroupmap/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">ActionGroupMap List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addActionGroupMap}> Add ActionGroupMap</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Security Group Map ID</th>
                                    
                                    <th>Action ID</th>
                                    
                                    <th>Organization</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.actiongroupmaps.map(
                                        actiongroupmap => 
                                        <tr key = { actiongroupmap.id }>

                                                <td> { actiongroupmap.id } </td>  
                                                
                                                <td> { actiongroupmap.action_id } </td>  
                                                
                                                <td> { actiongroupmap.action_group_id } </td>  
                                                
                                                <td> { actiongroupmap.is_active } </td>  
                                                
                                                <td> { actiongroupmap.created_by } </td>  
                                                
                                                <td> { actiongroupmap.last_updated } </td>  
                                                
                                                <td> { actiongroupmap.last_updated_by } </td>  
                                                
                                                <td> { actiongroupmap.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editActionGroupMap(actiongroupmap.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteActionGroupMap(actiongroupmap.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ActionGroupMapListComponent);