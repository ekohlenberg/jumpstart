import React, { Component } from 'react'
import OrgService from '../services/OrgService';

class OrgListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                orgs: []
        }
        this.addOrg = this.addOrg.bind(this);
        this.editOrg = this.editOrg.bind(this);
        this.deleteOrg = this.deleteOrg.bind(this);
    }

    deleteOrg(id){
        OrgService.deleteOrg(id).then( res => {
            this.setState({orgs: this.state.orgs.filter(org => org.id !== id)});
        });
    }
    viewOrg(id){
        this.props.history.push(`/view-org/${id}`);
    }
    editOrg(id){
        console.log("editing " + id)
        this.props.history.push(`/add-org/${id}`);
    }

    componentDidMount(){
        OrgService.getOrgs().then((res) => {
            this.setState({ orgs: res.data});
        });
    }

    addOrg(){
        this.props.history.push('/add-org/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Org List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addOrg}> Add Org</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>Organization ID</th>
                                    
                                    <th>Name</th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.orgs.map(
                                        org => 
                                        <tr key = {@(Model.DomainVar).id}>

                                                <td> {org.id)} </td>  
                                                
                                                <td> {org.name)} </td>  
                                                
                                                <td> {org.is_active)} </td>  
                                                
                                                <td> {org.created_by)} </td>  
                                                
                                                <td> {org.last_updated)} </td>  
                                                
                                                <td> {org.last_updated_by)} </td>  
                                                
                                                <td> {org.version)} </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editOrg(org.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteOrg(org.id)} className="btn btn-danger">Delete </button>
                                                
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

export default OrgListComponent;