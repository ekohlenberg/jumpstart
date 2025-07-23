import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import ScheduleService from '../services/schedule-service';

class ScheduleListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                schedules: []
        }
        this.addSchedule = this.addSchedule.bind(this);
        this.editSchedule = this.editSchedule.bind(this);
        this.deleteSchedule = this.deleteSchedule.bind(this);
    }

    deleteSchedule(id){
        ScheduleService.deleteSchedule(id).then( res => {
            this.setState({ schedules: this.state.schedules.filter(schedule => schedule.id !== id) });
        });
    }
    viewSchedule(id){
        this.props.navigate(`/view-schedule/${id}`);
    }
    editSchedule(id){
        console.log("editing " + id)
        this.props.navigate(`/add-schedule/${id}`);
    }

    componentDidMount(){
        ScheduleService.getSchedules().then((res) => {
            this.setState({ schedules: res.data});
        });
    }

    addSchedule(){
        this.props.navigate('/add-schedule/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Schedule List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addSchedule}> Add Schedule</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th></th>
                                    
                                    <th></th>
                                    
                                    <th></th>
                                    
                                    <th></th>
                                    
                                    <th></th>
                                    
                                    <th>Active</th>
                                    
                                    <th>Created By</th>
                                    
                                    <th>Last Updated</th>
                                    
                                    <th>Last Updated By</th>
                                    
                                    <th>Version</th>
                                        
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.schedules.map(
                                        schedule => 
                                        <tr key = { schedule.id }>

                                                <td> { schedule.id } </td>  
                                                
                                                <td> { schedule.cron_expression } </td>  
                                                
                                                <td> { schedule.next_run_time } </td>  
                                                
                                                <td> { schedule.last_run_time } </td>  
                                                
                                                <td> { schedule.status } </td>  
                                                
                                                <td> { schedule.is_active } </td>  
                                                
                                                <td> { schedule.created_by } </td>  
                                                
                                                <td> { schedule.last_updated } </td>  
                                                
                                                <td> { schedule.last_updated_by } </td>  
                                                
                                                <td> { schedule.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editSchedule(schedule.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteSchedule(schedule.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(ScheduleListComponent);