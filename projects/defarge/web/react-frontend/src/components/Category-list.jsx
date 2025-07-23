import React, { Component } from 'react'
import { withNavigation } from './with-navigation';

import CategoryService from '../services/category-service';

class CategoryListComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                categorys: []
        }
        this.addCategory = this.addCategory.bind(this);
        this.editCategory = this.editCategory.bind(this);
        this.deleteCategory = this.deleteCategory.bind(this);
    }

    deleteCategory(id){
        CategoryService.deleteCategory(id).then( res => {
            this.setState({ categorys: this.state.categorys.filter(category => category.id !== id) });
        });
    }
    viewCategory(id){
        this.props.navigate(`/view-category/${id}`);
    }
    editCategory(id){
        console.log("editing " + id)
        this.props.navigate(`/add-category/${id}`);
    }

    componentDidMount(){
        CategoryService.getCategorys().then((res) => {
            this.setState({ categorys: res.data});
        });
    }

    addCategory(){
        this.props.navigate('/add-category/_add');
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Category List</h2>
                 <div className = "row">
                    <button className="btn btn-primary" onClick={this.addCategory}> Add Category</button>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    
                                    <th>Parent</th>
                                    
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
                                    this.state.categorys.map(
                                        category => 
                                        <tr key = { category.id }>

                                                <td> { category.id } </td>  
                                                
                                                <td> { category.parent_id } </td>  
                                                
                                                <td> { category.name } </td>  
                                                
                                                <td> { category.is_active } </td>  
                                                
                                                <td> { category.created_by } </td>  
                                                
                                                <td> { category.last_updated } </td>  
                                                
                                                <td> { category.last_updated_by } </td>  
                                                
                                                <td> { category.version } </td>  
                                                                                             <td>
                                                 <button onClick={ () => this.editCategory(category.id)} className="btn btn-info">Update </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.deleteCategory(category.id)} className="btn btn-danger">Delete </button>
                                                
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

export default withNavigation(CategoryListComponent);