# BrainBuilder
Brain Builder is an online platform that allows users to take course tests, generate certificates upon completion, and securely authenticate users. This project is developed using ASP.NET with SQL Server.

## Features
1. User Authentication
    - Secure login and registration system.
    - Role-based access control (Admin, Instructor, Student).
    - Password hashing for security.
2. Online Course Test
    - Users can attempt multiple-choice or descriptive tests.
    - Timer functionality for time-bound exams.
    - Auto-evaluation for MCQs, manual evaluation for descriptive answers.
3. Certificate Generation
    - Automatic certificate generation upon successful test completion.
    - Certificate generated as a PNG image using System.Drawing in C#.
    - Customizable certificate templates with dynamic user details.
4. Admin & Instructor Dashboard
    - Manage users, courses, and tests.
    - View test results and issue certificates.
    - Analytics on student performance.
5. Database Management
- SQL Server used for efficient data handling.
- Tables for users, courses, test results, and certificates.
## Technology Stack
- **Frontend:** HTML, CSS, Bootstrap, JavaScript
- **Backend:** ASP.NET (C#)
- **Database:** SQL Server
  
## Usage
1. Register or log in to the platform.
2. Enroll in a course and complete the test.
3. Download the certificate upon passing the test.
4. Admin and instructors can manage users and generate reports.
   
## Future Enhancements
- Integration of AI-based question generation.
- Live proctoring for online exams.
- Mobile app support.
