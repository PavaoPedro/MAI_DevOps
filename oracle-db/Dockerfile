#imagem oracledb
FROM oracle/database:19.3.0-ee
EXPOSE 8080
EXPOSE 1521
ENV ORACLE_HOME /app/oracle/product/11.2.0/xe
ENV ORACLE_SID ORCL
ENV ORACLE_USER rm551600
ENV ORACLE_PASSWORD 030900
VOLUME ["/app/oracle/oracledata"]
CMD ["sh", "-c", "/oracle/product/19c/dbhome_1/bin/dbstart /oracle/product/19c/dbhome_1 && tail -f /dev/null"]