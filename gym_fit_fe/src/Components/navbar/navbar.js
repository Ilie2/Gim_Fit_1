import './navbar.css'
import { Link, useMatch , useResolvedPath } from 'react-router-dom'

export default function Navbar(){
    
    return <nav className="nav">
        <Link to="/" className="site-title">Gym fit</Link>
        <ul>
                <CustomLink to="/Courses">Courses</CustomLink>
                <CustomLink to="/Trainers">Trainers</CustomLink>           
                <CustomLink to="/Subscribe">Subscribe</CustomLink>
                <CustomLink to="/LoginForm">Login</CustomLink>
        </ul>
    </nav>
}

function CustomLink({to,children, ...props}){
    const resolvedpath = useResolvedPath(to)
    const isActive = useMatch({path: resolvedpath.pathname, end:true})
    return(
        <li className={isActive ? "active" : ""}>
            <Link to={to} {...props}> 
            {children}</Link>
        </li>
    )

    
}