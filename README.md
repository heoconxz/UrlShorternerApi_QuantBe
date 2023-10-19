# Url Shorterner Api
## CI/CD Plan:
1. CI/CD Pipeline Configuration<br>
Pipeline Triggers:<br> Configure triggers for your CI/CD pipeline to automatically start the deployment process upon code changes in the main branch and test branch of the repository.<br>
Deployment Environment:<br> Define deployment environment, whether it's a cloud-based platform like Azure, on-premises servers, or a container orchestration system.<br>

2. Deployment Process<br>
Dockerization:<br> the CI/CD pipeline should handle building and pushing Docker images.<br>
Deployment Automation:<br> Implement scripts or deployment orchestration tools within your pipeline to ensure consistency in deployment steps.<br>

3. Monitoring and Validation<br>
Health Checks:<br> Include health checks as part of the deployment process to verify the new instances are healthy before directing traffic to them.<br>
Deployment Testing:<br> Automate testing within the pipeline to verify the deployed service's functionality.<br>
Log Analysis:<br> Implement log analysis within the pipeline to catch any errors or issues during deployment.<br>

4. Post-Deployment<br>
Notifications:<br> Automate notifications to users if there's any planned maintenance or downtime. Use messaging platforms or email to keep users informed.<br>
Rollback Plan:<br> In case of issues, set up an automated rollback plan within the CI/CD pipeline, ensuring that you can revert to a known good state.<br>
Continuous Monitoring:<br> Implement continuous monitoring through your pipeline to detect and respond to issues immediately, potentially triggering automatic rollbacks when necessary.<br>

5. Review and Iteration<br>
Performance Metrics:<br> Assess the performance and stability of the deployed service based on monitoring data.<br>
Pipeline Optimization:<br> Identify areas for pipeline optimization, such as speeding up the deployment process or improving monitoring.<br>
Automated Testing Enhancements:<br> Consider expanding the automated test suite to cover additional scenarios and edge cases.<br>

## Potential gaps and solution:
1. Configuration and secrets management: <br>
Current cryptography encryption_key and salt are hard-coded. Consider using  tool like Azure Key Vault to store sensitive information.
2. Security: <br>
Consider implementing rate limiting and input validation.

3. Monitoring and Logging: <br>
For production, monitoring and logging are required. Consider implement both.

4. API versioning: <br>
Current solution doesn't consider API versioning.

5. Caching: <br>
Consider Caching to improve performance

6. Documentation: <br>
To keep this solution simple, any api documentation like OpenAPI or Swagger is removed. Consider implement this documentation as it help developer and clients
