const express = require("express");
const cors = require("cors");
const { Sequelize } = require("sequelize");
const LogEntry = require("./entities/LogEntry");

const app = express();
const port = process.env.PORT || 3000;

app.use(cors());
app.use(express.json());

const connection = new Sequelize(process.env.DB_URL);

app.get("/api/v1/logs", async (req, res) => {
  try {
    const entries = await LogEntry.findAll();

    res.status(200).json(entries);
  } catch (error) {
    console.error("Error fetching logs:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.post("/api/v1/logs", async (req, res) => {
  try {
    const { message, level, source } = req.body;
    console.log("Received log entry:", req.body);

    const errors = [];

    if (!message) errors.push("Message is required");
    if (!level) errors.push("Level is required");
    if (!source) errors.push("Source is required");
    if (level && !["info", "warn", "error"].includes(level))
      errors.push("Invalid level");

    if (errors.length > 0) {
      return res.status(400).json({ errors });
    }

    const newLogEntry = await LogEntry.create({ message, level, source });

    res.status(201).json(newLogEntry);
  } catch (error) {
    console.error("Error creating log entry:", error);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

app.listen(port, async () => {
  await LogEntry.sync({ force: true });
  console.log("The table for the LogEntry model was just (re)created!");
});
